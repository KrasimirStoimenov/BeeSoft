﻿// <auto-generated />
using System;
using BeeSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeeSoft.Data.Migrations
{
    [DbContext(typeof(BeeSoftDbContext))]
    [Migration("20240119093234_HiveBeeQueenRelationChangedToOneToManyInsteadOneToOne")]
    partial class HiveBeeQueenRelationChangedToOneToManyInsteadOneToOne
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeeSoft.Data.Models.Apiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Apiaries");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.BeeQueen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("HiveId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HiveId");

                    b.ToTable("BeeQueens");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HiveId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HiveId");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Harvest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("HarvestedAmount")
                        .HasColumnType("float");

                    b.Property<string>("HarvestedProduct")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HiveId");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Hive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiaryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("DateBought")
                        .HasColumnType("date");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TimesUsedCount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ApiaryId");

                    b.ToTable("Hives");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionsTaken")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("HiveId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("WeatherConditions")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HiveId");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.BeeQueen", b =>
                {
                    b.HasOne("BeeSoft.Data.Models.Hive", "Hive")
                        .WithMany("BeeQueens")
                        .HasForeignKey("HiveId");

                    b.Navigation("Hive");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Disease", b =>
                {
                    b.HasOne("BeeSoft.Data.Models.Hive", "Hive")
                        .WithMany("Diseases")
                        .HasForeignKey("HiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hive");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Harvest", b =>
                {
                    b.HasOne("BeeSoft.Data.Models.Hive", "Hive")
                        .WithMany("Harvests")
                        .HasForeignKey("HiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hive");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Hive", b =>
                {
                    b.HasOne("BeeSoft.Data.Models.Apiary", "Apiary")
                        .WithMany("Hives")
                        .HasForeignKey("ApiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apiary");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Inspection", b =>
                {
                    b.HasOne("BeeSoft.Data.Models.Hive", "Hive")
                        .WithMany("Inspections")
                        .HasForeignKey("HiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hive");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Apiary", b =>
                {
                    b.Navigation("Hives");
                });

            modelBuilder.Entity("BeeSoft.Data.Models.Hive", b =>
                {
                    b.Navigation("BeeQueens");

                    b.Navigation("Diseases");

                    b.Navigation("Harvests");

                    b.Navigation("Inspections");
                });
#pragma warning restore 612, 618
        }
    }
}
