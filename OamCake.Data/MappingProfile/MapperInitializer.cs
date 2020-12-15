using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OamCake.Data.MappingProfile
{
    public static class MapperInitializer
    {
        public static void RegisterMappings(this IServiceCollection services) 
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.IsSubclassOf(typeof(Profile)));
            services.AddAutoMapper(types.ToArray());
        }
    }
}
