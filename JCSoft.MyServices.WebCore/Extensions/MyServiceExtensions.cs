using JCSoft.MyServices.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace JCSoft.MyServices.WebCore.Extensions
{
    public static class MyServiceExtensions
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var dict = GetClassName(typeof(IScope).Assembly.FullName);
            foreach(var key in dict.Keys)
            {
                AddTypeToServicesFactory(key, dict[key], services);
            }
            return services;
        }

        private static Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            if (!String.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> ts = assembly.GetTypes().ToList();

                var result = new Dictionary<Type, Type[]>();
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }

        private static void AddTypeToServicesFactory(Type type, Type[] types, IServiceCollection services)
        {
            AddTypeToServices(type, types, typeof(IScope), (face, desc) =>
            {
                services.TryAddScoped(face, desc);
            });

            AddTypeToServices(type, types, typeof(ITran), (face, desc) =>
            {
                services.TryAddTransient(face, desc);
            });

            AddTypeToServices(type, types, typeof(ISingle), (face, desc) =>
            {
                services.TryAddSingleton(face, desc);
            });
        }

        private static void AddTypeToServices(Type type, Type[] types, Type needType, Action<Type, Type> action)
        {
            if (types.Any(i => i == needType))
            {
                foreach(var addType in types)
                {
                    if (addType != needType)
                    {
                        action?.Invoke(addType, type);
                    }
                }
            }
        }
    }
}
