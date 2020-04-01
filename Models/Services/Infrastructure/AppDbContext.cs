using Microsoft.EntityFrameworkCore;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private DbContextOptions<AppDbContext> _options;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)    
        {            
            _options = options;
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