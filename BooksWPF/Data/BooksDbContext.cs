using System;
using System.Collections.Generic;
using BooksWPF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksWPF.Data
{
    public partial class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
        }

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Save> Saves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-HHA694E;Database=BooksDb;Integrated Security=True;");
            }
            //Server=DESKTOP-HHA694E;Database=BooksDb;Integrated Security=True;
            //System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<User>()
         .HasOne(a => a.Save)
         .WithOne(b => b.User)
         .HasForeignKey<User>(s => s.SaveId);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
