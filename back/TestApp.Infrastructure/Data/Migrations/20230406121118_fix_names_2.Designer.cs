﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApp.Infrastructure.Data;

#nullable disable

namespace TestApp.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230406121118_fix_names_2")]
    partial class fix_names_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestApp.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountrydId")
                        .HasColumnType("int");

                    b.Property<int>("Identity")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountrydId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProvinceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestApp.Core.Entities.UserAggregade.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TestApp.Core.Entities.UserAggregade.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("TestApp.Core.Entities.User", b =>
                {
                    b.HasOne("TestApp.Core.Entities.UserAggregade.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountrydId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestApp.Core.Entities.UserAggregade.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("TestApp.Core.Entities.UserAggregade.Province", b =>
                {
                    b.HasOne("TestApp.Core.Entities.UserAggregade.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
