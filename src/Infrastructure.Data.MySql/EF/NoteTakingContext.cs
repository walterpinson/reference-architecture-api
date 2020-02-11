using System;
using System.Collections.Generic;
using System.Text;
using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.EF
{
    public class NoteTakingContext : DbContext
    {
        public DbSet<MySqlNote> Note { get; set; }
        public DbSet<MySqlCategory> Category { get; set; }
        public DbSet<MySqlSubscriber> Subscriber { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=notetaking;User=root;Password=Summer!2345;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MySqlCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnType("CHAR(36)");
                entity.HasMany<MySqlNote>();
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


