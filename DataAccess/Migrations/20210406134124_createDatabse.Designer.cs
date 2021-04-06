﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(advYumitGyulerContext))]
    [Migration("20210406134124_createDatabse")]
    partial class createDatabse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Arrived"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Exercise"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cage"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Left"
                        });
                });

            modelBuilder.Entity("Entities.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("HamsterId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("AreaId");

                    b.HasIndex("HamsterId");

                    b.ToTable("ActivityLogs");
                });

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 4,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 5,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 6,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 7,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 8,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 9,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 10,
                            AreaTypeId = 1,
                            Capacity = 3,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 11,
                            AreaTypeId = 2,
                            Capacity = 6,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("Entities.AreaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AreaTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cage"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Exercise"
                        });
                });

            modelBuilder.Entity("Entities.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerFullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = (byte)4,
                            Gender = "M",
                            Name = "Rufus",
                            OwnerFullName = "Kallegurra Aktersnurra"
                        },
                        new
                        {
                            Id = 2,
                            Age = (byte)12,
                            Gender = "K",
                            Name = "Lisa",
                            OwnerFullName = "Kallegurra Aktersnurra"
                        },
                        new
                        {
                            Id = 3,
                            Age = (byte)11,
                            Gender = "M",
                            Name = "Fluff",
                            OwnerFullName = "Carl Hamilton"
                        },
                        new
                        {
                            Id = 4,
                            Age = (byte)10,
                            Gender = "M",
                            Name = "Nibbler",
                            OwnerFullName = "Carl Hamilton"
                        },
                        new
                        {
                            Id = 5,
                            Age = (byte)9,
                            Gender = "M",
                            Name = "Sneaky",
                            OwnerFullName = "Lisa Nilsson"
                        },
                        new
                        {
                            Id = 6,
                            Age = (byte)8,
                            Gender = "K",
                            Name = "Sussi",
                            OwnerFullName = "Lisa Nilsson"
                        },
                        new
                        {
                            Id = 7,
                            Age = (byte)7,
                            Gender = "K",
                            Name = "Mulan",
                            OwnerFullName = "Jan Hallgren"
                        },
                        new
                        {
                            Id = 8,
                            Age = (byte)6,
                            Gender = "K",
                            Name = "Miss Diggy",
                            OwnerFullName = "Ottilla Murkwood"
                        },
                        new
                        {
                            Id = 9,
                            Age = (byte)5,
                            Gender = "M",
                            Name = "Kalle",
                            OwnerFullName = "Anfers Murkwood"
                        },
                        new
                        {
                            Id = 10,
                            Age = (byte)4,
                            Gender = "M",
                            Name = "Kurt",
                            OwnerFullName = "Anna Book"
                        },
                        new
                        {
                            Id = 11,
                            Age = (byte)4,
                            Gender = "K",
                            Name = "Starlight",
                            OwnerFullName = "Anna Book"
                        },
                        new
                        {
                            Id = 12,
                            Age = (byte)3,
                            Gender = "M",
                            Name = "Chivas",
                            OwnerFullName = "Pernilla Wahlgren"
                        },
                        new
                        {
                            Id = 13,
                            Age = (byte)3,
                            Gender = "K",
                            Name = "Malin",
                            OwnerFullName = "Bianca Ingrosso"
                        },
                        new
                        {
                            Id = 14,
                            Age = (byte)24,
                            Gender = "M",
                            Name = "Bulle",
                            OwnerFullName = "Lorenzo Lamas"
                        },
                        new
                        {
                            Id = 15,
                            Age = (byte)23,
                            Gender = "M",
                            Name = "Beppe",
                            OwnerFullName = "Bobby Ewing"
                        },
                        new
                        {
                            Id = 16,
                            Age = (byte)22,
                            Gender = "K",
                            Name = "Bobo",
                            OwnerFullName = "Hedy Lamar"
                        },
                        new
                        {
                            Id = 17,
                            Age = (byte)21,
                            Gender = "K",
                            Name = "Robin",
                            OwnerFullName = "Bette Davis"
                        },
                        new
                        {
                            Id = 18,
                            Age = (byte)20,
                            Gender = "K",
                            Name = "Amber",
                            OwnerFullName = "Kim Carnes"
                        },
                        new
                        {
                            Id = 19,
                            Age = (byte)19,
                            Gender = "M",
                            Name = "Kimber",
                            OwnerFullName = "Mork of Ork"
                        },
                        new
                        {
                            Id = 20,
                            Age = (byte)18,
                            Gender = "K",
                            Name = "Ruby",
                            OwnerFullName = "Mindy Mendel"
                        },
                        new
                        {
                            Id = 21,
                            Age = (byte)16,
                            Gender = "K",
                            Name = "Fiffi",
                            OwnerFullName = "GW Hansson"
                        },
                        new
                        {
                            Id = 22,
                            Age = (byte)16,
                            Gender = "K",
                            Name = "Neko",
                            OwnerFullName = "Pia Hansson"
                        },
                        new
                        {
                            Id = 23,
                            Age = (byte)15,
                            Gender = "M",
                            Name = "Clint",
                            OwnerFullName = "Bo Ek"
                        },
                        new
                        {
                            Id = 24,
                            Age = (byte)14,
                            Gender = "M",
                            Name = "Sauron",
                            OwnerFullName = "Anna Al"
                        },
                        new
                        {
                            Id = 25,
                            Age = (byte)12,
                            Gender = "K",
                            Name = "Gittan",
                            OwnerFullName = "Hans Björk"
                        },
                        new
                        {
                            Id = 26,
                            Age = (byte)110,
                            Gender = "M",
                            Name = "Crawler",
                            OwnerFullName = "Carita Gran"
                        },
                        new
                        {
                            Id = 27,
                            Age = (byte)9,
                            Gender = "K",
                            Name = "Mimmi",
                            OwnerFullName = "Mia Eriksson"
                        },
                        new
                        {
                            Id = 28,
                            Age = (byte)8,
                            Gender = "M",
                            Name = "Marvel",
                            OwnerFullName = "Anna Linström"
                        },
                        new
                        {
                            Id = 29,
                            Age = (byte)7,
                            Gender = "M",
                            Name = "Storm",
                            OwnerFullName = "Lennart Berg"
                        },
                        new
                        {
                            Id = 30,
                            Age = (byte)6,
                            Gender = "K",
                            Name = "Busan",
                            OwnerFullName = "Bo Bergman"
                        });
                });

            modelBuilder.Entity("Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Available"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Unavailable"
                        });
                });

            modelBuilder.Entity("Entities.ActivityLog", b =>
                {
                    b.HasOne("Entities.Activity", "Activity")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Area", "Area")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("AreaId");

                    b.HasOne("Entities.Hamster", "Hamster")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("HamsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Area");

                    b.Navigation("Hamster");
                });

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.HasOne("Entities.AreaType", "AreaType")
                        .WithMany("Areas")
                        .HasForeignKey("AreaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Status", "Status")
                        .WithMany("Areas")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Entities.Activity", b =>
                {
                    b.Navigation("ActivityLogs");
                });

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.Navigation("ActivityLogs");
                });

            modelBuilder.Entity("Entities.AreaType", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("Entities.Hamster", b =>
                {
                    b.Navigation("ActivityLogs");
                });

            modelBuilder.Entity("Entities.Status", b =>
                {
                    b.Navigation("Areas");
                });
#pragma warning restore 612, 618
        }
    }
}
