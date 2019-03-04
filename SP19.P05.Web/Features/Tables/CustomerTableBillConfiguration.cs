using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Tables
{
    public class CustomerTableBillConfiguration : IEntityTypeConfiguration<CustomerTableBill>
    {
        public void Configure(EntityTypeBuilder<CustomerTableBill> builder)
        {
            builder.HasKey(x => new {x.TableBillId, x.CustomerId});
        }
    }
}