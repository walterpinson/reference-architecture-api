using System;
using System.Collections.Generic;
using System.Text;
using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.EF
{
    public class NoteTakingContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<MySqlNote> Note { get; set; }
        public DbSet<MySqlCategory> Category { get; set; }
        public DbSet<MySqlSubscriber> Subscriber { get; set; }

        public NoteTakingContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MySqlCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnType("CHAR(36)");
            });

            modelBuilder.Entity<MySqlNote>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnType("CHAR(36)");
                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<MySqlSubscriber>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnType("CHAR(36)");
                entity.Property(e => e.EmailAddress).IsRequired();
            });
        }
    }
}


