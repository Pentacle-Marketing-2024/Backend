using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Repository.Models;

namespace Repository.DataAccess
{
    public partial class Pentacle_MarketingContext : DbContext
    {
        public Pentacle_MarketingContext()
        {
        }

        public Pentacle_MarketingContext(DbContextOptions<Pentacle_MarketingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Form> Forms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            return configuration.GetConnectionString("DefaultConnectionStringDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}