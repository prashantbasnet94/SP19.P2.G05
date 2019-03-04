using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Tables
{
    public class TableFoodItemConfiguration : IEntityTypeConfiguration<TableFoodItem>
    {
        public void Configure(EntityTypeBuilder<TableFoodItem> builder)
        {
            builder.Property(x => x.Discount)
                .HasColumnType("decimal(38,16)");
        }
    }
}