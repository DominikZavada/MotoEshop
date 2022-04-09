﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotoEshop.Models.Database;

namespace MotoEshop.Migrations
{
    [DbContext(typeof(EshopDBContext))]
    [Migration("20220320211212_MySQL_1_7")]
    partial class MySQL_1_7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("MotoEshop.Models.Carousel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarouselContent")
                        .IsRequired();

                    b.Property<string>("DataTarget")
                        .IsRequired();

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("Carousels");
                });

            modelBuilder.Entity("MotoEshop.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<double>("TotalPrice");

                    b.HasKey("ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MotoEshop.Models.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<int>("OrderID");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductID");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("MotoEshop.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasMaxLength(225);

                    b.Property<double>("Price");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MotoEshop.Models.OrderItem", b =>
                {
                    b.HasOne("MotoEshop.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MotoEshop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
