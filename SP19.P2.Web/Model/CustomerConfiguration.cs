using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(x => x.MailingAddress).Property(c => c.StreetNumber).HasColumnName("StreetNumber");
            builder.OwnsOne(x => x.MailingAddress).Property(c => c.StreetName).HasColumnName("StreetName");
            builder.OwnsOne(x => x.MailingAddress).Property(c => c.City).HasColumnName("City");
            builder.OwnsOne(x => x.MailingAddress).Property(c => c.State).HasColumnName("State");
            builder.OwnsOne(x => x.MailingAddress).Property(c => c.Zip).HasColumnName("Zip");
            builder.ToTable("Customer", "Customer");
        }
    }
}
