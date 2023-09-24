﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Data;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230924154209_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserService.Model.Groups", b =>
                {
                    b.Property<string>("idGroup")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameGroup")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idGroup");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("UserService.Model.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"), 1L, 1);

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nameUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("statusUser")
                        .HasColumnType("bit");

                    b.HasKey("idUser");

                    b.HasIndex("idGroup");

                    b.ToTable("users");
                });

            modelBuilder.Entity("UserService.Model.User", b =>
                {
                    b.HasOne("UserService.Model.Groups", "groups")
                        .WithMany("users")
                        .HasForeignKey("idGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("groups");
                });

            modelBuilder.Entity("UserService.Model.Groups", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
