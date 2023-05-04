using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transflo.Assessment.Core.Domain;

namespace Transflo.Assessment.Infrastructure.Persistence.Seeds
{
    public class DriverSeed
    {
        private readonly IServiceProvider _serviceProvider;

        public DriverSeed(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SeedDriversAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TransfloAssessmentContext>();

            if (await context.Drivers.AnyAsync())
            {
                // Database has already been seeded
                return;
            }

            var faker = new Faker<Driver>()
                .RuleFor(d => d.FirstName, f => f.Person.FirstName)
                .RuleFor(d => d.LastName, f => f.Person.LastName)
                .RuleFor(d => d.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.EmailAddress, f => f.Person.Email);

            var drivers = faker.Generate(100);

            await context.AddRangeAsync(drivers);
            await context.SaveChangesAsync();
        }
    }


}
