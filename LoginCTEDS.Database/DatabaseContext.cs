using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCTEDS.Database
{
    internal class DatabaseContext : DbContext
    {
        internal DbSet<UserModel> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            if (!ob.IsConfigured)
            {
                ob.UseSqlite($"Data Source=database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<UserModel>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.userName)
                    .HasName("userName");

                entity.Property(e => e.userName)
                    .HasColumnName("userName");

                entity.Property(e => e.password)
                    .HasColumnName("password")
                    .IsRequired();
            });
        }
    }
}
