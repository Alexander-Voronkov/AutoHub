﻿// <auto-generated />
using System;
using AutoHub.Modules.Adverts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoHub.Modules.Adverts.Infrastructure.Migrations
{
    [DbContext(typeof(AdvertsContext))]
    [Migration("20240614204544_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AutoHub.BuildingBlocks.Application.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", "meetings");
                });

            modelBuilder.Entity("AutoHub.BuildingBlocks.Infrastructure.Inbox.InboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InboxMessages", "adverts");
                });

            modelBuilder.Entity("AutoHub.BuildingBlocks.Infrastructure.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EnqueueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Error")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands", "adverts");
                });

            modelBuilder.Entity("AutoHub.Modules.Adverts.Domain.Adverts.Advert", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Adverts", "adverts");
                });

            modelBuilder.Entity("AutoHub.Modules.Adverts.Domain.Adverts.Advert", b =>
                {
                    b.OwnsOne("AutoHub.Modules.Adverts.Domain.Adverts.Cost", "_cost", b1 =>
                        {
                            b1.Property<Guid>("AdvertId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("_cost")
                                .HasColumnType("decimal(65,30)")
                                .HasColumnName("Cost");

                            b1.Property<string>("_currencyCode")
                                .HasColumnType("longtext")
                                .HasColumnName("Currency");

                            b1.HasKey("AdvertId");

                            b1.ToTable("Adverts", "adverts");

                            b1.WithOwner()
                                .HasForeignKey("AdvertId");
                        });

                    b.Navigation("_cost");
                });
#pragma warning restore 612, 618
        }
    }
}
