using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Transflo.Assessment.Core.Domain;

namespace Transflo.Assessment.Infrastructure.Persistence.EntitiesConfiguration
{
    internal class DriverConfig : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(p => p.LastName).HasMaxLength(PersistenceConstants.EntityColumnSizeConstants.ShortTextLength);
            builder.Property(p => p.FirstName).HasMaxLength(PersistenceConstants.EntityColumnSizeConstants.ShortTextLength);
            builder.Property(p => p.PhoneNumber).HasMaxLength(PersistenceConstants.EntityColumnSizeConstants.ShortTextLength);
            builder.Property(p => p.EmailAddress).HasMaxLength(PersistenceConstants.EntityColumnSizeConstants.EmailTextLength);
        }
    }
}
