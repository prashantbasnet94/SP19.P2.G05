﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SP19.P2.Web.Model;

namespace SP19.P2.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190206044958_datacontext")]
    partial class datacontext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SP19.P2.Web.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(30);

                    b.Property<string>("State")
                        .HasMaxLength(30);

                    b.Property<string>("StreetName")
                        .HasMaxLength(128);

                    b.Property<int>("StreetNumber");

                    b.Property<int>("Zip")
                        .HasMaxLength(5);

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MailingAddressAddressId");

                    b.Property<int?>("PaymentOptionId");

                    b.Property<int?>("RelatedUserUserId");

                    b.Property<int?>("TableBillId");

                    b.HasKey("CustomerId");

                    b.HasIndex("MailingAddressAddressId");

                    b.HasIndex("PaymentOptionId");

                    b.HasIndex("RelatedUserUserId");

                    b.HasIndex("TableBillId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.LineItem", b =>
                {
                    b.Property<int>("LineItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<int>("PerItemCost");

                    b.Property<int?>("ReceiptId");

                    b.HasKey("LineItemId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(6);

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<int?>("MenuId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Price");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.PaymentOption", b =>
                {
                    b.Property<int>("PaymentOptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BillingAddressAddressId");

                    b.Property<string>("Nickname")
                        .HasMaxLength(64);

                    b.Property<int?>("ReceiptId");

                    b.Property<string>("TokenizedCardReference")
                        .HasMaxLength(128);

                    b.HasKey("PaymentOptionId");

                    b.HasIndex("BillingAddressAddressId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("PaymentOptions");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateOfPayment");

                    b.Property<int?>("LineItemId");

                    b.Property<int>("PaymentAuthenticationNumber");

                    b.Property<int?>("PaymentOptionId");

                    b.Property<int>("PaymentReferenceNumber");

                    b.Property<int?>("ServerUserId");

                    b.Property<int?>("TableId");

                    b.Property<int>("Total");

                    b.HasKey("ReceiptId");

                    b.HasIndex("LineItemId");

                    b.HasIndex("PaymentOptionId");

                    b.HasIndex("ServerUserId");

                    b.HasIndex("TableId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<int?>("UserId");

                    b.HasKey("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfSeats");

                    b.Property<string>("TableType")
                        .HasMaxLength(5);

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.TableBill", b =>
                {
                    b.Property<int>("TableBillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTimeOffset>("EndTime");

                    b.Property<DateTimeOffset>("StartTime");

                    b.Property<int?>("TableFoodItemId");

                    b.Property<int?>("TableId");

                    b.HasKey("TableBillId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableFoodItemId");

                    b.HasIndex("TableId");

                    b.ToTable("TableBills");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.TableFoodItem", b =>
                {
                    b.Property<int>("TableFoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOrdered");

                    b.Property<int>("Discount");

                    b.Property<int?>("MenuItemId");

                    b.Property<int?>("TableBillId");

                    b.HasKey("TableFoodItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("TableBillId");

                    b.ToTable("TableFoodItems");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<int?>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Customer", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.Address", "MailingAddress")
                        .WithMany()
                        .HasForeignKey("MailingAddressAddressId");

                    b.HasOne("SP19.P2.Web.Model.PaymentOption", "PaymentOption")
                        .WithMany()
                        .HasForeignKey("PaymentOptionId");

                    b.HasOne("SP19.P2.Web.Model.User", "RelatedUser")
                        .WithMany()
                        .HasForeignKey("RelatedUserUserId");

                    b.HasOne("SP19.P2.Web.Model.TableBill")
                        .WithMany("Customers")
                        .HasForeignKey("TableBillId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.LineItem", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.Receipt")
                        .WithMany("LineItems")
                        .HasForeignKey("ReceiptId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.MenuItem", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.PaymentOption", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressAddressId");

                    b.HasOne("SP19.P2.Web.Model.Receipt")
                        .WithMany("PaymentOptions")
                        .HasForeignKey("ReceiptId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Receipt", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.LineItem", "LineItem")
                        .WithMany()
                        .HasForeignKey("LineItemId");

                    b.HasOne("SP19.P2.Web.Model.PaymentOption", "PaymentOption")
                        .WithMany()
                        .HasForeignKey("PaymentOptionId");

                    b.HasOne("SP19.P2.Web.Model.User", "Server")
                        .WithMany()
                        .HasForeignKey("ServerUserId");

                    b.HasOne("SP19.P2.Web.Model.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.Role", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.TableBill", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("SP19.P2.Web.Model.TableFoodItem", "TableFoodItem")
                        .WithMany()
                        .HasForeignKey("TableFoodItemId");

                    b.HasOne("SP19.P2.Web.Model.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.TableFoodItem", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId");

                    b.HasOne("SP19.P2.Web.Model.TableBill")
                        .WithMany("TableFoodItems")
                        .HasForeignKey("TableBillId");
                });

            modelBuilder.Entity("SP19.P2.Web.Model.User", b =>
                {
                    b.HasOne("SP19.P2.Web.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SP19.P2.Web.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
