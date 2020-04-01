using System;
using ISSCFG.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private DbContextOptions<AppDbContext> Options;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)    
        {            
            Options = options; 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {        
            var extension = Options.FindExtension<NpgsqlOptionsExtension>();
            if (extension != null) {
                optionsBuilder.UseNpgsql(extension.ConnectionString);                
            } else {
                string extensionString = "{";
                foreach (var e in Options.Extensions)
                    extensionString += e.GetType() + "},";
                extensionString += "}";
                throw new ArgumentException($@"
                    In Microsoft.EntityFrameworkCore.DbContextOptionsBuilder can't find 
                    Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal.NpgsqlOptionsExtension extension
                    Available extensions are: {extensionString} NpgsqlOptionsExtension");     
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.Entity<Item>(entity =>
            {            
                entity.ToTable("Items");
                entity.HasKey(item => item.Id);
                entity.Property(item => item.Id).ValueGeneratedOnAdd();

                entity.HasData(new Item("QM55R") { 
                    Id = -1,
                    Producer = "SAMSUNG",
                    Description = "Samsung Smart Signage Display",
                    ImagePath = "img/Items/QM55R.jpg",
                    Url = "https://displaysolutions.samsung.com/digital-signage/detail/1431/QM55R"
                });
                entity.HasData(new Item("WM65R") { 
                    Id = -2,
                    Producer = "SAMSUNG",
                    Description = "Flip 2 - SMART Signage",
                    ImagePath = "img/Items/FLIP2_65.jpg",
                    Url = "https://www.samsung.com/it/samsung-flip/"
                });                
                entity.HasData(new Item("STUDIO") { 
                    Id = -3,
                    Producer = "POLY",
                    Description = "Premium USB Video Bar",
                    ImagePath = "img/Items/STUDIO.jpg",
                    Url = "https://www.polycom.com/hd-video-conferencing/room-video-systems/polycom-studio.html"
                });
                entity.HasData(new Item("STUDIO-X30") { 
                    Id = -4,
                    Producer = "POLY",
                    Description = "Poly Studio X30",
                    ImagePath = "img/Items/STUDIO-X30.jpg",
                    Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x30-data-sheet-enus.pdf"
                });
                entity.HasData(new Item("STUDIO-X50") { 
                    Id = -5,
                    Producer = "POLY",
                    Description = "Poly Studio X50",
                    ImagePath = "img/Items/STUDIO-X50.jpg",
                    Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x50-data-sheet-enus.pdf"
                });                
                entity.HasData(new Item("CS_CX-20") { 
                    Id = -6,
                    Producer = "BARCO",
                    Description = "ClickShare CX-20",
                    ImagePath = "img/Items/CX-20.png",
                    Url = "https://www.barco.com/en/clickshare/wireless-conferencing/cx-20"
                });
                entity.HasData(new Item("VCEM") { 
                    Id = -7,
                    Producer = "BARCO",
                    Description = "VC Studio Expansion Microphone",
                    ImagePath = "",
                    Url = ""
                });
            });

            modelBuilder.Entity<UserInput>(entity =>
            {            
                entity.ToTable("UserInputs");
                entity.HasKey(input => input.Id);
                entity.Property(input => input.Id).ValueGeneratedOnAdd();            
            });
        }        
    
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<UserInput> UserInputs { get; set; }        
    }
}