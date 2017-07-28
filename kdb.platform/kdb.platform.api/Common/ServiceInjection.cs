using kdb.platform.services;
using kdb.platform.services.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kdb.platform.api.Common
{
    public class ServiceInjection
    {
        public static void ConfigureBusiness(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
