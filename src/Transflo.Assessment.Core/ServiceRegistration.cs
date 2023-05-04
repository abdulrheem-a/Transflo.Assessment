using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Transflo.Assessment.Core
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddTransfloAssessmentCoreLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
            return services;
        }
    }
}