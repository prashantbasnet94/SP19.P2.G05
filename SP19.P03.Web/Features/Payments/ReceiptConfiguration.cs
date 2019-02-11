using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SP19.P03.Web.Features.Payments;

namespace SP19.P03.Web.Data
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.Property(x => x.TotalAmount)
                .HasColumnType("decimal(38,16)");
            builder.Property(x => x.ReferenceNumber)
                .HasMaxLength(16);
            builder.Property(x => x.AuthNumber)
                .HasMaxLength(16);
        }
    }
}