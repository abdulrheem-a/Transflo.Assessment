using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Transflo.Assessment.Core.Domain;
using Transflo.Assessment.Infrastructure.Persistence.Seeds;

namespace Transflo.Assessment.Infrastructure.Persistence
{
    internal class TransfloAssessmentContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public TransfloAssessmentContext(DbContextOptions<TransfloAssessmentContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
