using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P03.Web.Features.LineItems
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.Property(x => x.Price)
                .HasColumnType("decimal(38,16)");
            builder.Property(x => x.Name)
                .HasMaxLength(128);
            builder.Property(x => x.Description)
                .HasMaxLength(512);
            builder.Property(x => x.PictureUrl)
                .HasMaxLength(1024);
        }
    }
}