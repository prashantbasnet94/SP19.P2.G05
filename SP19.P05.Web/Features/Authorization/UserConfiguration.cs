using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Authorization
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email)
                .HasMaxLength(1024);
            builder.Property(x => x.Phone)
                .HasMaxLength(16);
            builder.Property(x => x.Name)
                .HasMaxLength(256);
        }
    }
}