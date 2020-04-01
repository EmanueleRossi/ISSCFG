using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace ISSCFG.Models.Services.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private DbContextOptions<AppDbContext> _options;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)    
        {            
            _options = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var extension = _options.FindExtension<NpgsqlOptionsExtension>();
            if (extension != null) {
                optionsBuilder.UseNpgsql(extension.ConnectionString);
            } else {
                throw new ArgumentException("This DB Context supports only Postgres, using Npgsql.EntityFrameworkCore.PostgreSQL NUGET package!");
            }
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