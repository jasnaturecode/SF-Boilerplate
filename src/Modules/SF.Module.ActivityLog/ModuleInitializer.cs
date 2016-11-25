﻿
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SF.Core;
using SF.Core.Data;
using SF.Core.Interceptors;
using SF.Module.ActivityLog.Data;
using SF.Core.Services;

namespace SF.Module.ActivityLog
{
    public class ModuleInitializer : ModuleInitializerBase, IModuleInitializer
    {
        public override IEnumerable<KeyValuePair<int, Action<IServiceCollection>>> ConfigureServicesActionsByPriorities
        {
            get
            {
                return new Dictionary<int, Action<IServiceCollection>>()
                {
                    [10000] = this.AddActivityService
                };
            }
        }
        public void AddActivityService(IServiceCollection services)
        {
            services.AddSingleton<IActivityUnitOfWork>(sp =>
            {
                var simpleDbContext = sp.GetService<CoreDbContext>();
                var userNameResolver = sp.GetService<IUserNameResolver>();
                return new ActivityUnitOfWork(simpleDbContext, new AuditableInterceptor(userNameResolver));
            });


        }


    }
}
