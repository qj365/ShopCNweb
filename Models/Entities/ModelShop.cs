using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopCNweb.Models.Entities
{
    public partial class ModelShop : DbContext
    {
        public ModelShop()
            : base("name=ModelShop")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.FULLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.IDCATEGORY);

            modelBuilder.Entity<Products>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Products>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.PHOTO)
                .IsUnicode(false);
        }
    }
}
