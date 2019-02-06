using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SP19.P2.Web.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableFoodItem> TableFoodItems { get; set; }
        public DbSet<TableBill> TableBills { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

    }
}