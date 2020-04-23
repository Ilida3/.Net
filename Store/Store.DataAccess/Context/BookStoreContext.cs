using System;
using System.Collections.Generic;
using System.Text;
using Store.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Store.DataAccess.Context
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Author).IsRequired();
                entity.Property(c => c.Price).IsRequired();
                entity.Property(c => c.Year).IsRequired();
            });

        modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(m => m.FirstName).IsRequired();
                entity.Property(m => m.LastName).IsRequired();
                entity.Property(m => m.MiddleName).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(s => s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(s => s.Date).IsRequired();
                entity.Property(s => s.Time).IsRequired();
                entity.HasOne(s => s.Book)
                    .WithMany(c => c.Order)
                    .HasForeignKey(s => s.BookId)
                    .HasConstraintName("FK_Order_Book");
                entity.HasOne(s => s.Client)
                    .WithMany(m => m.Order).HasForeignKey(s => s.ClientId)
                    .HasConstraintName("FK_Order_Client");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
