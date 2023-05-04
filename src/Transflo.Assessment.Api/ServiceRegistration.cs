using Transflo.Assessment.Core;
using Transflo.Assessment.Infrastructure;

namespace Transflo.Assessment.Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPresentationLayerServices(this IServiceCollection services)
        {

            services.AddTransfloAssessmentInfrastructureInfrastructureLayer();
            services.AddTransfloAssessmentCoreLayer();
            return services;
        }

    }
}
