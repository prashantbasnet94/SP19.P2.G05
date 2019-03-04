using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Payments
{
    public class PaymentOptionConfiguration : IEntityTypeConfiguration<PaymentOption>
    {
        public void Configure(EntityTypeBuilder<PaymentOption> builder)
        {
            builder.Property(x => x.Nickname)
                .HasMaxLength(16);
            builder.Property(x => x.TokenizedCardReference)
                .HasMaxLength(32);
        }
    }
}