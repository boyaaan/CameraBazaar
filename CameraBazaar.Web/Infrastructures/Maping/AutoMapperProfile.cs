namespace CameraBazaar.Web.Infrastructure.Maping
{
    using AutoMapper;
    using CameraBazaar.Comon;
    using System;
    using System.Linq;
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name.Contains("CameraBazaar"))
                .SelectMany(t => t.GetTypes());

            allTypes
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                     .Where(i => i.IsGenericType)
                     .Select(i => i.GetGenericTypeDefinition())
                     .Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Destination = t,
                    Sourse = t
                     .GetInterfaces()
                     .Where(i => i.IsGenericType)
                     .Select(i => new
                     {
                         Definition = i.GetGenericTypeDefinition(),
                         Arguments = i.GetGenericArguments()
                     })
                     .Where(i => i.Definition == typeof(IMapFrom<>))
                     .SelectMany(i => i.Arguments)
                     .First()
                })
                .ToList()
                .ForEach(t => this.CreateMap(t.Sourse, t.Destination));

            allTypes
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IHaveCustomMaping).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHaveCustomMaping>()
                .ToList()
                .ForEach(t => t.ConfigureMapping(this));
        }
    }
}
