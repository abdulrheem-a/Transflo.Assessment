using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Transflo.Assessment.Core.Features.Drivers.GetAlphabetizedDriverById;
using Transflo.Assessment.Core.Interfaces.Repositories;
using Transflo.Assessment.Infrastructure.Persistence;
using Transflo.Assessment.Infrastructure.Persistence.Repositories;
using Transflo.Assessment.Infrastructure.Persistence.Seeds;
using Transflo.Assessment.Shared.Models.Settings;

namespace Transflo.Assessment.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddTransfloAssessmentInfrastructureInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<TransfloAssessmentContext>(options =>
            options.UseSqlServer(TransfloAssessmentSetting.ApplicationConnectionString));
            services.RegisterServices();
  
            return services;
        }
        static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<DriverSeed>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IReadonlyRepository<>), typeof(ReadonlyRepository<>));
            services.AddTransient<IGetAlphabetizedDriverByIdQueryRepository, GetAlphabetizedDriverByIdQueryRepository>();
        }
    }
}