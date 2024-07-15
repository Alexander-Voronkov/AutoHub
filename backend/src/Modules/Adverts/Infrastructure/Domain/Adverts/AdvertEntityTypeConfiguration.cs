using AutoHub.Modules.Adverts.Domain.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoHub.Modules.Adverts.Infrastructure.Domain.Adverts;

internal class AdvertEntityTypeConfiguration : IEntityTypeConfiguration<Advert>
{
    public void Configure(EntityTypeBuilder<Advert> builder)
    {
        builder.ToTable("Adverts", "adverts");

        builder.OwnsOne<Cost>("_cost", c =>
        {
            c.Property(x => x._cost).HasColumnName("Cost");
            c.Property(x => x._currencyCode).HasColumnName("Currency");
        });

        builder.HasKey(x => x.Id);
    }
}