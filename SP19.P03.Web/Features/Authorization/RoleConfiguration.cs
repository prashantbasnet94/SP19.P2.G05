using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P03.Web.Features.Authorization
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(32);

            builder.HasData(new List<Role>
            {
                new Role {Id = 1, Name = "Admin"},
                new Role {Id = 2, Name = "Customer"},
                new Role {Id = 3, Name = "Manager"},
                new Role {Id = 4, Name = "Server"}
            });
        }
    }
}