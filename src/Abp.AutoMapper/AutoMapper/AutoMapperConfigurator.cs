using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Reflection;
using AutoMapper;

namespace Abp.AutoMapper
{
    internal static class AutoMapperConfigurator
    {
        public static void FindAndAutoMapTypes(ITypeFinder typeFinder)
        {
            var types = typeFinder.Find(t => !t.IsAbstract && !t.IsInterface).ToArray();

            Mapper.Initialize(cfg =>
            {
                LoadMapFromMappings(cfg, types);
                LoadMapToMappings(cfg, types);
                LoadCustomMappings(cfg, types);
            });
        }

        private static void LoadCustomMappings(IConfiguration cfg, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(ICustomMappings).IsAssignableFrom(t)
                        select (ICustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(cfg);
            }
        }

        private static void LoadMapFromMappings(IConfiguration cfg, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadMapToMappings(IConfiguration cfg, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Destination = i.GetGenericArguments()[0],
                            Source = t
                        }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Source, map.Destination);
            }
        }
    }
}
