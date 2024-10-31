using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");  
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.Address).HasColumnType("text");
            });

       
            modelBuilder.Entity<User>()
                .HasMany(u => u.Carts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserID);

            
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartDetails)
                .WithOne(cd => cd.Cart)
                .HasForeignKey(cd => cd.CartID);

            modelBuilder.Entity<CartDetail>()
                .HasOne(cd => cd.Book)
                .WithMany() 
                .HasForeignKey(cd => cd.BookID);

      
            modelBuilder.Entity<Catalogue>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Catalogue)
                .HasForeignKey(b => b.GenreID);
        }
    }
}