using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using kdb.platform.commons;
using kdb.platform.api.Common;
using AutoMapper;
using kdb.platform.repositorys.DataProvide;
using Hangfire;
using Hangfire.MySql;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web;

namespace kdb.platform.api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        public IConfigurationRoot Configuration { get; }

        private MapperConfiguration _mapperConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Convert.ToBoolean(Configuration["AppSettings:usemysql"]))
                services.AddTransient<ISqlContext, MySqlContext>();
            else
                services.AddTransient<ISqlContext, MsSqlContext>();

            RepositoryInjection.ConfigureRepository(services);
            ServiceInjection.ConfigureBusiness(services);
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

            services.AddCors(options =>// 允许跨域访问
            {
                options.AddPolicy("AllowSameDomain", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowCredentials();
                });
            });
            // Add Hangfire services.
            services.AddHangfire(r => r.UseStorage(new MySqlStorage(Configuration["AppSettings:MySqlConnectionStrings"])));

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute))).AddJsonOptions(opt =>
            {
                opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = ".net core 基础框架 api 接口", Version = "v1" });
                c.OperationFilter<AddAuthTokenHeaderParameter>(); // 手动高亮
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();//添加NLog

            env.ConfigureNLog("nlog.config");

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            //loggerFactory.AddDebug();

            app.UseCors(builder =>//跨域访问的设置
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //自定义密钥
            var secretKey = "ThisIsASecretKeyForAspNetCoreAPIToken";
            //生成SymmetricSecurityKey密钥
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            //令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = "issuer",
                ValidateAudience = true,
                ValidAudience = "audience",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero

            };
            // 使用Jwt持票人身份验证
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            // 任务
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ".net core 基础框架 api 接口 v1");
            });
        }
    }
}
