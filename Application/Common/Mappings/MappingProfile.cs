using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace JobList.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var interfaceType = typeof(IMapFrom<>);

            var methodName = nameof(IMapFrom<object>.Mapping);
            var methodArgs = new Type[] { typeof(Profile) };

            var types = assembly.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .ToList();

            foreach (var type in types)
            {
                var iMapInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);

                if(iMapInterface != null)
                {
                    var instance = Activator.CreateInstance(type);

                    var methodInfo = iMapInterface.GetMethod(methodName, methodArgs);

                    methodInfo?.Invoke(instance, new object[] { this });
                }                
            }
        }
    }
}
