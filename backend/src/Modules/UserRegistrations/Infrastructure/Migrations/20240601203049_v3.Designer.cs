﻿// <auto-generated />
using System;
using AutoHub.Modules.UserRegistrations.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Migrations
{
    [DbContext(typeof(RegistrationsContext))]
    [Migration("20240601203049_v3")]
    partial class v3
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

                    b.ToTable("OutboxMessages", "registrations");
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

                    b.ToTable("InboxMessages", "registrations");
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

                    b.ToTable("InternalCommands", "registrations");
                });

            modelBuilder.Entity("AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.UserRegistration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("_confirmedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("ConfirmedDate");

                    b.Property<string>("_email")
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("_firstName")
                        .HasColumnType("longtext")
                        .HasColumnName("FirstName");

                    b.Property<string>("_lastName")
                        .HasColumnType("longtext")
                        .HasColumnName("LastName");

                    b.Property<string>("_login")
                        .HasColumnType("longtext")
                        .HasColumnName("Login");

                    b.Property<string>("_name")
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.Property<string>("_password")
                        .HasColumnType("longtext")
                        .HasColumnName("Password");

                    b.Property<DateTime>("_registerDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("RegisterDate");

                    b.HasKey("Id");

                    b.ToTable("UserRegistrations", "registrations");
                });

            modelBuilder.Entity("AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.UserRegistration", b =>
                {
                    b.OwnsOne("AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.UserRegistrationStatus", "_status", b1 =>
                        {
                            b1.Property<Guid>("UserRegistrationId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("longtext")
                                .HasColumnName("StatusCode");

                            b1.HasKey("UserRegistrationId");

                            b1.ToTable("UserRegistrations", "registrations");

                            b1.WithOwner()
                                .HasForeignKey("UserRegistrationId");
                        });

                    b.Navigation("_status");
                });
#pragma warning restore 612, 618
        }
    }
}
