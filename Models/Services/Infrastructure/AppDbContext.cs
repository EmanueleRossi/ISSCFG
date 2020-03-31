using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)    
        {            
            _contextOptions = contextOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {        
            optionsBuilder.UseNpgsql(@"Host=34.77.109.48;Database=isscfg;Username=isscfg_usr;Password=jw8s0F4ò;");
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {            
                entity.ToTable("Items");
                entity.HasKey(item => item.Id);
            });
        }        
    
        public virtual DbSet<Item> Items { get; set; }
    }
}