﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaveSyncNew.Data;

#nullable disable

namespace SaveSyncNew.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20230512095606_FixTypeColumn")]
    partial class FixTypeColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SaveSyncNew.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar");

                    b.Property<string>("LicenseCode")
                        .HasColumnType("nchar(4)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar");

                    b.Property<int?>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShopCode")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("SubDistrict")
                        .HasColumnType("nvarchar");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}