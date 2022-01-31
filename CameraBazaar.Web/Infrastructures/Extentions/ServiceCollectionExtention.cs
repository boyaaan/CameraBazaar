﻿namespace CameraBazaar.Web.Infrastructure.Extentions
{
    using CameraBazaar.Service;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddDomainServices(
          this IServiceCollection service)
        {
            Assembly
                .GetAssembly(typeof(IServices))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => service.AddTransient(s.Interface, s.Implementation));

            return service;
        }
    }
}
