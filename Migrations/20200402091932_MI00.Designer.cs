﻿// <auto-generated />
using ISSCFG.Models.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ISSCFG.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200402091932_MI00")]
    partial class MI00
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ISSCFG.Models.Entities.UserInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Step01")
                        .HasColumnType("text");

                    b.Property<string>("Step02")
                        .HasColumnType("text");

                    b.Property<string>("Step03")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserInputs");
                });

            modelBuilder.Entity("ISSCFG.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Code = "QM55R",
                            Description = "Samsung Smart Signage Display",
                            ImagePath = "~/img/Products/QM55R.jpeg",
                            Producer = "SAMSUNG",
                            Url = "https://displaysolutions.samsung.com/digital-signage/detail/1431/QM55R"
                        },
                        new
                        {
                            Id = -2,
                            Code = "WM65R",
                            Description = "Flip 2 - SMART Signage",
                            ImagePath = "~/img/Products/FLIP2_65.jpeg",
                            Producer = "SAMSUNG",
                            Url = "https://www.samsung.com/it/samsung-flip/"
                        },
                        new
                        {
                            Id = -3,
                            Code = "STUDIO",
                            Description = "Premium USB Video Bar",
                            ImagePath = "~/img/Products/STUDIO.jpeg",
                            Producer = "POLY",
                            Url = "https://www.polycom.com/hd-video-conferencing/room-video-systems/polycom-studio.html"
                        },
                        new
                        {
                            Id = -4,
                            Code = "STUDIO-X30",
                            Description = "Poly Studio X30",
                            ImagePath = "~/img/Products/STUDIO-X30.jpeg",
                            Producer = "POLY",
                            Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x30-data-sheet-enus.pdf"
                        },
                        new
                        {
                            Id = -5,
                            Code = "STUDIO-X50",
                            Description = "Poly Studio X50",
                            ImagePath = "~/img/Products/STUDIO-X50.jpeg",
                            Producer = "POLY",
                            Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x50-data-sheet-enus.pdf"
                        },
                        new
                        {
                            Id = -6,
                            Code = "CS_CX-20",
                            Description = "ClickShare CX-20",
                            ImagePath = "~/img/Products/CX-20.png",
                            Producer = "BARCO",
                            Url = "https://www.barco.com/en/clickshare/wireless-conferencing/cx-20"
                        },
                        new
                        {
                            Id = -7,
                            Code = "VCEM",
                            Description = "VC Studio Expansion Microphone",
                            ImagePath = "~/img/ACS.jpeg",
                            Producer = "BARCO",
                            Url = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}