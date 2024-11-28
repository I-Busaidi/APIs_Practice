using API_Practice1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practice1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                        .HasIndex(e => e.AdminEmail)
                        .IsUnique();

            modelBuilder.Entity<User>()
                        .HasIndex(e => e.Email)
                        .IsUnique();

            modelBuilder.Entity<Category>()
                        .HasIndex(e => e.CatName)
                        .IsUnique();

            modelBuilder.Entity<Book>()
                        .HasIndex(e => e.BookName)
                        .IsUnique();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}
