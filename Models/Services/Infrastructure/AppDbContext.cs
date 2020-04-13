using ISSCFG.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)    
        {            
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
                    ImagePath = "~/img/Products/QM55R.jpeg",
                    Url = "https://displaysolutions.samsung.com/digital-signage/detail/1431/QM55R"
                });
                entity.HasData(new Item("WM65R") { 
                    Id = -2,
                    Producer = "SAMSUNG",
                    Description = "Flip 2 - SMART Signage",
                    ImagePath = "~/img/Products/FLIP2_65.jpeg",
                    Url = "https://www.samsung.com/it/samsung-flip/"
                });                
                entity.HasData(new Item("STUDIO") { 
                    Id = -3,
                    Producer = "POLY",
                    Description = "Premium USB Video Bar",
                    ImagePath = "~/img/Products/STUDIO.jpeg",
                    Url = "https://www.polycom.com/hd-video-conferencing/room-video-systems/polycom-studio.html"
                });
                entity.HasData(new Item("STUDIO-X30") { 
                    Id = -4,
                    Producer = "POLY",
                    Description = "Poly Studio X30",
                    ImagePath = "~/img/Products/STUDIO-X30.jpeg",
                    Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x30-data-sheet-enus.pdf"
                });
                entity.HasData(new Item("STUDIO-X50") { 
                    Id = -5,
                    Producer = "POLY",
                    Description = "Poly Studio X50",
                    ImagePath = "~/img/Products/STUDIO-X50.jpeg",
                    Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x50-data-sheet-enus.pdf"
                });                
                entity.HasData(new Item("CS_CX-20") { 
                    Id = -6,
                    Producer = "BARCO",
                    Description = "ClickShare CX-20",
                    ImagePath = "~/img/Products/CX-20.png",
                    Url = "https://www.barco.com/en/clickshare/wireless-conferencing/cx-20"
                });
                entity.HasData(new Item("VCEM") { 
                    Id = -7,
                    Producer = "BARCO",
                    Description = "VC Studio Expansion Microphone",
                    ImagePath = "~/img/Products/VCEM.jpeg",
                    Url = ""
                });
                entity.HasData(new Item("TC8") { 
                    Id = -8,
                    Producer = "POLY",
                    Description = "Poly TC8 Tablet",
                    ImagePath = "~/img/Products/TC8.jpeg",
                    Url = "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/poly-tc8-data-sheet-enus.pdf"                    
                });                
                entity.HasData(new Item("ACS_PRE-CFG") { 
                    Id = -9,
                    Producer = "ACS",
                    Description = "Configurazione: aggiornamento firmware, set-up...",
                    ImagePath = "~/img/ACS.jpeg",
                    Url = ""
                });  
                entity.HasData(new Item("ACS_REMOTE-SUPPORT") { 
                    Id = -10,
                    Producer = "ACS",
                    Description = "Supporto remoto in fase di installazione",
                    ImagePath = "~/img/ACS.jpeg",
                    Url = ""
                });               
                entity.HasData(new Item("MS-TRL") { 
                    Id = -11,
                    Producer = "Microsoft",
                    Description = "Meeting Room License",
                    ImagePath = "~/img/Products/MS-TRL.jpeg",
                    Url = "https://office365itpros.com/2018/12/17/teams-device-meeting-license/"
                });                                      
            });

            modelBuilder.Entity<UserInput>(entity =>
            {            
                entity.ToTable("UserInputs");
                entity.HasKey(input => input.Id);
                entity.Property(input => input.Id).ValueGeneratedOnAdd();  
                entity.Property(input => input.InsertDate).HasComment("Application level entity creation date, in UTC.");
            });
        }        
    
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<UserInput> UserInputs { get; set; }        
    }
}