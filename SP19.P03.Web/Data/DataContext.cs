using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SP19.P03.Web.Features.Customers;
using SP19.P03.Web.Features.Authorization;
using SP19.P03.Web.Features.Tables;

namespace SP19.P03.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public DbSet<SP19.P03.Web.Features.Customers.Customer> Customer { get; set; }

        public DbSet<SP19.P03.Web.Features.Authorization.Role> Role { get; set; }

        public DbSet<SP19.P03.Web.Features.Authorization.User> User { get; set; }

        public DbSet<SP19.P03.Web.Features.Tables.Table> Table { get; set; }
    }
}
