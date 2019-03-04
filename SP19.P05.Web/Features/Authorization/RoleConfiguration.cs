using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Authorization
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new List<Role>
            {
                new Role {Id = 1, Name = "Admin", NormalizedName = "ADMIN"},
                new Role {Id = 2, Name = "Customer", NormalizedName = "CUSTOMER"},
                new Role {Id = 3, Name = "Manager", NormalizedName = "MANAGER"},
                new Role {Id = 4, Name = "Server", NormalizedName = "SERVER"}
            });
        }
    }
}