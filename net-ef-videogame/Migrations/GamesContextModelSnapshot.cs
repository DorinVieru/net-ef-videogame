﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_ef_videogame;

#nullable disable

namespace net_ef_videogame.Migrations
{
    [DbContext(typeof(GamesContext))]
    partial class GamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("net_ef_videogame.Games", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("release_date");

                    b.Property<long>("SoftwareHouseId")
                        .HasColumnType("bigint")
                        .HasColumnName("software_house_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_at");

                    b.HasKey("GameId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.HasIndex("SoftwareHouseId");

                    b.ToTable("games");
                });

            modelBuilder.Entity("net_ef_videogame.SoftwareHouse", b =>
                {
                    b.Property<long>("SoftwareHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SoftwareHouseId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tax_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("SoftwareHouseId");

                    b.HasIndex("SoftwareHouseId")
                        .IsUnique();

                    b.ToTable("software_house");
                });

            modelBuilder.Entity("net_ef_videogame.Games", b =>
                {
                    b.HasOne("net_ef_videogame.SoftwareHouse", "SoftwareHouse")
                        .WithMany()
                        .HasForeignKey("SoftwareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareHouse");
                });
#pragma warning restore 612, 618
        }
    }
}
