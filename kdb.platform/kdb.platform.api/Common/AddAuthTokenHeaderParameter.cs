using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kdb.platform.api.Common
{
    /// <summary>
    /// Swagger 测试的时候添加token
    /// </summary>
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
            var attrs = context.ApiDescription.ActionAttributes();
            foreach (var attr in attrs)
            {
                // 如果 Attribute 是我们自定义的验证过滤器
                if (attr.GetType() == typeof(AuthorizeAttribute))
                {
                    operation.Parameters.Add(new NonBodyParameter()
                    {
                        Name = "Authorization",
                        In = "header",
                        Type = "string",
                        Required = false
                    });
                }
            }
        }
    }
}
