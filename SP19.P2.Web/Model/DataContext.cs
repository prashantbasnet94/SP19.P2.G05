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
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<MailingAddress> MailingAddresses { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            //UserRole Many-to-Many Relationship 
            modelBuilder.Entity<UserRole>()
                .HasKey(u => new { u.UserId, u.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId);




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




            //dustin
            //Seed Data
            //Users
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    UserId = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "jsmith@gmail.com",
                    Phone = "111-111-1111"
                },

          new User
          {
              UserId = 2,
              FirstName = "Bob",
              LastName = "Richards",
              Email = "bbrich@gmail.com",
              Phone = "111-111-1221"
          },

         new User
         {
             UserId = 3,
             FirstName = "Lisa",
             LastName = "Smith",
             Email = "lsmith@gmail.com",
             Phone = "123-111-1111"
         },

           new User
           {
               UserId = 4,
               FirstName = "Lee",
               LastName = "Williams",
               Email = "leeWill@gmail.com",
               Phone = "111-222-1111"
           },

            new User
            {
                UserId = 5,
                FirstName = "Customer1",
                LastName = "Smith",
                Email = "cust1@gmail.com",
                Phone = "111-151-1111"
            }

            );



            modelBuilder.Entity<Role>().HasData(


            new Role
            {

                RoleId = 100,
                Name = " Admin",
                Description = "checks the site"
            }, new Role
            {

                RoleId = 101,
                Name = " Customer",
                Description = "checks the site"
            }, new Role
            {

                RoleId = 102,
                Name = " Manager",
                Description = "checks the site"
            }, new Role
            {

                RoleId = 103,
                Name = " Server",
                Description = "checks the site"
            }



                );

            //UserRole 
            modelBuilder.Entity<UserRole>().HasData(

                new UserRole
                {
                    UserId = 1,
                    RoleId = 100
                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 101
                },
                new UserRole
                {
                    UserId = 3,
                    RoleId = 102
                },
                new UserRole
                {
                    UserId = 4,
                    RoleId = 103
                }
                );















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
                 AmountOrdered = 100,
                 Discount = 10

             },
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
                Customer = 1000,
                StartTime = DateTimeOffset.Now,
                EndTime = DateTimeOffset.Now,
                TableFoodItemId = 1,
                TableId = 1

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


            //Customer
            modelBuilder.Entity<Customer>().HasData(

                new Customer
                {
                    CustomerId = 31,
                    UserId = 4,
                    PaymentOption = 120,
                MailingAddressId = 80
                },

                new Customer
                {
                    CustomerId = 32,
                    UserId = 1,
                    PaymentOption = 121,
                    MailingAddressId =81
                }, new Customer
                {
                    CustomerId = 33,
                    UserId = 2,
                    PaymentOption = 122,
                    MailingAddressId = 82
                },

                new Customer
                {
                    CustomerId = 34,
                    UserId = 3,
                    PaymentOption = 123,
                    MailingAddressId = 83
                }


            );

            //Mailing Address
            modelBuilder.Entity<MailingAddress>().HasData(

                new MailingAddress
                {
                    MailingAddressId = 80,
                    Address= "3221 South Morrison Blvd. Hammond LA, 70401",
                    OwnedType="Apt"
                }, 
                new MailingAddress
                {
                    MailingAddressId = 81,
                    Address = "901 South Morrison Blvd. Hammond LA, 70401",
                    OwnedType = "Rent"
                },
                 new MailingAddress
                 {
                     MailingAddressId = 82,
                     Address = " North Morrison Blvd. Hammond LA, 70401",
                     OwnedType = "Own"
                 },
                  new MailingAddress
                  {
                      MailingAddressId = 83,
                      Address = " East Morrison Blvd. Hammond LA, 70401",
                      OwnedType = "Shared"
                  }


            );

            //Mailing Address
            modelBuilder.Entity<PaymentOption>().HasData(

                new PaymentOption
                {
                    PaymentOptionId = 120,
                    TokenizedCardReference = "xvagas121212",
                   Nickname ="Visa x000",
                    BillingAddressId = 80
                },
                 new PaymentOption
                 {
                     PaymentOptionId = 121,
                     TokenizedCardReference="Adsds121212",
                     Nickname = "Master x111",
                     BillingAddressId = 81
                 }, new PaymentOption
                 {
                     PaymentOptionId = 122,
                     TokenizedCardReference = "Qsatardsds121212",
                     Nickname = "Credit x000",
                     BillingAddressId = 83
                 }, new PaymentOption
                 {
                     PaymentOptionId = 123,
                     TokenizedCardReference = "zexybra121212",
                     Nickname = "Checking x000",
                     BillingAddressId = 82
                 }

            );



              
        //Mailing Address
        modelBuilder.Entity<Receipt>().HasData(

                new Receipt
                {

                    ReceiptId = 180,
                    LineItemId=220,
                    PaymentOptionId = 120,      
                    Total = 124,
                    DateOfPayment = DateTimeOffset.Now,
                    PaymentReferenceNumber = 1222122,
                    PaymentAuthenticationNumber = 152251,
                    Table = 1
                },
                 new Receipt
                 {

                     ReceiptId = 181,
                     PaymentOptionId = 121,
                     LineItemId = 221,
                     Total = 1024,
                     DateOfPayment = DateTimeOffset.Now,
                     PaymentReferenceNumber = 112122,
                     PaymentAuthenticationNumber = 2152251,
                     Table = 2
                 },
                  new Receipt
                  {

                      ReceiptId = 182,
                      LineItemId = 222,
                      PaymentOptionId = 122,
                      Total = 3324,
                      DateOfPayment = DateTimeOffset.Now,
                      PaymentReferenceNumber = 1221212122,
                      PaymentAuthenticationNumber = 152251,
                      Table = 3
                  },
                 new Receipt
                 {

                     ReceiptId = 183,
                     PaymentOptionId = 123,
                     LineItemId = 223,
                     Total = 2024,
                     DateOfPayment = DateTimeOffset.Now,
                     PaymentReferenceNumber = 112122,
                     PaymentAuthenticationNumber = 2152251,
                     Table = 4
                 }



            );



            //Mailing Address
            modelBuilder.Entity<LineItem>().HasData(

                new LineItem
                {
                     
                     LineItemId =220,
                     Description ="Awesome",
                     PerItemCost=12,
                      Amount=121

                 }, new LineItem
                 {

                     LineItemId = 221,
                     Description = "not so good",
                     PerItemCost = 12,
                     Amount = 121

                 }, new LineItem
                 {

                     LineItemId = 222,
                     Description = "bad",
                     PerItemCost = 12,
                     Amount = 121

                 }, new LineItem
                 {

                     LineItemId = 223,
                     Description = "Good",
                     PerItemCost = 12,
                     Amount = 121

                 }
            


            );






           






    }


    }

    }
