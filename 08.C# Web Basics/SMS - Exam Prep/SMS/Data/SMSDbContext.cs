namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;

    using SMS.Data.Models;

    // ReSharper disable once InconsistentNaming
    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}