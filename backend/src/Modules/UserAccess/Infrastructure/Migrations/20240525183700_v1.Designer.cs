﻿// <auto-generated />
using System;
using AutoHub.Modules.UserAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoHub.Modules.UserAccess.Infrastructure.Migrations
{
    [DbContext(typeof(UserAccessContext))]
    [Migration("20240525183700_v1")]
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

                    b.ToTable("OutboxMessages", "users");
                });

            modelBuilder.Entity("AutoHub.BuildingBlocks.Infrastructure.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands", "users");
                });

            modelBuilder.Entity("AutoHub.Modules.UserAccess.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("_email")
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("_firstName")
                        .HasColumnType("longtext")
                        .HasColumnName("FirstName");

                    b.Property<bool>("_isActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IsActive");

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

                    b.HasKey("Id");

                    b.ToTable("Users", "users");
                });

            modelBuilder.Entity("AutoHub.Modules.UserAccess.Domain.User", b =>
                {
                    b.OwnsMany("AutoHub.Modules.UserAccess.Domain.Users.UserRole", "_roles", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .HasColumnType("varchar(255)")
                                .HasColumnName("RoleCode");

                            b1.HasKey("UserId", "Value");

                            b1.ToTable("UserRoles", "users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("_roles");
                });
#pragma warning restore 612, 618
        }
    }
}
