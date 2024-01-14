﻿// <auto-generated />
using System;
using Lab04.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab04.Migrations
{
    [DbContext(typeof(MarketDbContext))]
    partial class MarketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab04.Models.Advertisement", b =>
                {
                    b.Property<string>("AdvertisementId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileName");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image");

                    b.HasKey("AdvertisementId");

                    b.HasIndex("BrokerageId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Lab04.Models.Brokerage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brokerage", (string)null);
                });

            modelBuilder.Entity("Lab04.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Lab04.Models.Subscription", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("BrokerageId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClientId", "BrokerageId");

                    b.HasIndex("BrokerageId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Lab04.Models.Advertisement", b =>
                {
                    b.HasOne("Lab04.Models.Brokerage", "Brokerage")
                        .WithMany("Advertisements")
                        .HasForeignKey("BrokerageId");

                    b.Navigation("Brokerage");
                });

            modelBuilder.Entity("Lab04.Models.Subscription", b =>
                {
                    b.HasOne("Lab04.Models.Brokerage", "Brokerage")
                        .WithMany("Subscriptions")
                        .HasForeignKey("BrokerageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab04.Models.Client", "Client")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brokerage");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Lab04.Models.Brokerage", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Lab04.Models.Client", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
