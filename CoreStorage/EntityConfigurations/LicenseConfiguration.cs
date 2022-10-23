using CoreBussiness.BussinessEntity.Licenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfigurations;

public class LicenseConfiguration:IEntityTypeConfiguration<License>
{
    public void Configure(EntityTypeBuilder<License> builder)
    {
        builder.Property(x => x.Name).IsRequired(false);
        builder.Property(x => x.LastName).IsRequired(false);
        builder.Property(x => x.CompanyName).IsRequired(false);
        builder.Property(x => x.ConstPhone).IsRequired(false);
        builder.Property(x => x.LegalCode).IsRequired(false);
        builder.Property(x => x.LicenseCode).IsRequired(false);
        builder.Property(x => x.ClientCount);
        builder.Property(x => x.AppSerialCount);
        builder.Property(x => x.PhoneNumber).IsRequired(false);
        builder.Property(x => x.CompanyAddress).IsRequired(false);
    }
}