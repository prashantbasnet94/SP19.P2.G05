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
        public DbSet<MenuJoinMenuItem> MenuJoinMenuItems { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuJoinMenuItem>()
               .HasKey(u => new { u.MenuId, u.MenutItemId });

            modelBuilder.Entity<MenuJoinMenuItem>()
                .HasOne(ur => ur.Menu)
                .WithMany(u => u.MenuJoinMenuItems)
                .HasForeignKey(ur => ur.MenuId);

            modelBuilder.Entity<MenuJoinMenuItem>()
                .HasOne(ur => ur.MenuItem)
                .WithMany(u => u.MenuJoinMenuItems)
                .HasForeignKey(ur => ur.MenutItemId);



            modelBuilder.Entity<MenuItem>().HasData(



                new MenuItem
                {

                    MenuItemId = 10,
                    Name = "sandwiches",
                    Description = "awesome",
                    Price = 20,
                    Picture = "www.sandwiches.com"




                },
                new MenuItem
                {

                    MenuItemId = 11,
                    Name = "Nuggets",
                    Description = "awesome",
                    Price = 40,
                    Picture = "www.Nuggets.com"




                },
                new MenuItem
                {

                    MenuItemId = 12,
                    Name = "taco",
                    Description = "awesome",
                    Price = 20,
                    Picture = "www.taco.com"




                },
                new MenuItem
                {

                    MenuItemId = 13,
                    Name = "buritos",
                    Description = "awesome",
                    Price = 20,
                    Picture = "www.buritos.com"




                }

                );







            modelBuilder.Entity<Menu>().HasData(

                new Menu
                {
                    MenuId = 1,

                    Name = "Lunch Menu"
                },
                 new Menu
                 {
                     MenuId = 2,

                     Name = "Entre Menu"
                 },
                  new Menu
                  {
                      MenuId = 3,

                      Name = "Desert Menu"
                  }





                );








            modelBuilder.Entity<MenuJoinMenuItem>().HasData(

                new MenuJoinMenuItem
                {
                    MenuId = 1,
                    MenutItemId = 10

                },


                new MenuJoinMenuItem
                {
                    MenuId = 1,
                    MenutItemId = 11

                },
                new MenuJoinMenuItem
                {
                    MenuId = 1,
                    MenutItemId = 12

                },
                new MenuJoinMenuItem
                {
                    MenuId = 1,
                    MenutItemId = 13

                }


                );



            modelBuilder.Entity<Table>().HasData(

              new Table
              {
                  TableId = 1,
                  TableType = "Round Type",
                  NumberOfSeats = 10


              },

              new Table
              {
                  TableId = 2,
                  TableType = "Bar Height Table",
                  NumberOfSeats = 20


              },

              new Table
              {
                  TableId = 3,
                  TableType = "Family Dining Table",
                  NumberOfSeats = 20


              },
               new Table
               {
                   TableId = 4,
                   TableType = "Outdoor Table",
                   NumberOfSeats = 5


               }





              );




            modelBuilder.Entity<TableFoodItem>().HasData(

             new TableFoodItem
             {
                 TableFoodItemId = 1,
                 MenuItemId = 10,
                 AmountOrdered=100,
                 Discount=10

             } ,
              new TableFoodItem
              {
                  TableFoodItemId = 2,
                  MenuItemId = 11,
                  AmountOrdered = 110,
                  Discount = 20

              },
               new TableFoodItem
               {
                   TableFoodItemId = 3,
                   MenuItemId = 12,
                   AmountOrdered = 119,
                   Discount = 0

               }



             );

            modelBuilder.Entity<TableBill>().HasData(

            new TableBill
            {
                TableBillId = 50,
                 Customer=1000,
                StartTime = DateTimeOffset.Now,
                EndTime = DateTimeOffset.Now,
                TableFoodItemId=1,
                TableId=1

            },
            new TableBill
            {
                TableBillId = 51,
                Customer = 1001,
                StartTime = DateTimeOffset.Now,
                EndTime = DateTimeOffset.Now,
                TableFoodItemId = 2,
                TableId = 2
            },

              new TableBill
              {
                  TableBillId = 52,
                  Customer = 1002,
                StartTime = DateTimeOffset.Now,
                  EndTime = DateTimeOffset.Now,
                  TableFoodItemId = 3,
                  TableId = 3

              }



            );












        }

    }

}
