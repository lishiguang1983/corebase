using kdb.platform.repositorys;
using kdb.platform.repositorys.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kdb.platform.api.Common
{
    public class RepositoryInjection
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
