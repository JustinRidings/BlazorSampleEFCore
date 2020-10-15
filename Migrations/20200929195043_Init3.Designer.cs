﻿// <auto-generated />
using System;
using BangTestDemo2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BangTestDemo2.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20200929195043_Init3")]
    partial class Init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BangTestDemo2.Data.Models.CabSet", b =>
                {
                    b.Property<int>("CabsetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CabConfigLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CabCount")
                        .HasColumnType("int");

                    b.Property<string>("CabTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CabsetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CabsetId");

                    b.ToTable("CabsetDatabase");
                });

            modelBuilder.Entity("BangTestDemo2.Data.Models.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsReleased")
                        .HasColumnType("bit");

                    b.Property<int>("PackageFileCount")
                        .HasColumnType("int");

                    b.Property<string>("PackageHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageId");

                    b.ToTable("PackageDatabase");
                });

            modelBuilder.Entity("BangTestDemo2.Data.Models.Results", b =>
                {
                    b.Property<int>("ResultKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CabId")
                        .HasColumnType("int");

                    b.Property<int>("CabsetId")
                        .HasColumnType("int");

                    b.Property<string>("FailureString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasSymbolIssue")
                        .HasColumnType("bit");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RunId")
                        .HasColumnType("int");

                    b.Property<int>("TotalCpuMs")
                        .HasColumnType("int");

                    b.Property<int>("TotalElapsedMs")
                        .HasColumnType("int");

                    b.Property<string>("XmlPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResultKey");

                    b.ToTable("ResultsDatabase");
                });

            modelBuilder.Entity("BangTestDemo2.Data.Models.Run", b =>
                {
                    b.Property<int>("RunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasePackageId")
                        .HasColumnType("int");

                    b.Property<string>("BasePackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CabsCompleted")
                        .HasColumnType("int");

                    b.Property<int>("CabsetId")
                        .HasColumnType("int");

                    b.Property<int>("ComparisonPackageId")
                        .HasColumnType("int");

                    b.Property<string>("ComparisonPackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RunSubmissionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCabCount")
                        .HasColumnType("int");

                    b.HasKey("RunId");

                    b.ToTable("RunDatabase");
                });
#pragma warning restore 612, 618
        }
    }
}