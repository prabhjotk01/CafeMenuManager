using CafeMenuManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuManager.DAL
{
    public class CafeMenuContext : DbContext
    {
        public CafeMenuContext(DbContextOptions<CafeMenuContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // MenuItem
            modelBuilder.Entity<MenuItem>()
                .HasKey(m => m.MenuItemId);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(10,2)");

            // One-to-Many: Category -> MenuItems
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Category)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ingredient
            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.IngredientId);

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Many-to-Many: MenuItem <-> Ingredient
            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.Ingredients)
                .WithMany(i => i.MenuItems)
                .UsingEntity(j => j.ToTable("MenuItemIngredients"));
        }
    }
}
