using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class PaymentOptionConfiguration : IEntityTypeConfiguration<PaymentOption>
    {
        public void Configure(EntityTypeBuilder<PaymentOption> builder)
        {
            builder.OwnsOne(x => x.BillingAddress).Property(c => c.StreetNumber).HasColumnName("StreetNumber");
            builder.OwnsOne(x => x.BillingAddress).Property(c => c.StreetName).HasColumnName("StreetName");
            builder.OwnsOne(x => x.BillingAddress).Property(c => c.City).HasColumnName("City");
            builder.OwnsOne(x => x.BillingAddress).Property(c => c.State).HasColumnName("State");
            builder.OwnsOne(x => x.BillingAddress).Property(c => c.Zip).HasColumnName("Zip");
            builder.ToTable("PaymentOption", "PaymentOption");
        }
    }
}
