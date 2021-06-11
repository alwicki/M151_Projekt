using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients {get; set;}
        public DbSet<Unit> Units {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Like> Likes {get; set;}
        public DbSet<Tag> Tags {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
            .HasMany(u => u.Favorites)
            .WithMany(u => u.Users)
            .UsingEntity(j => j.ToTable("Favorites"));

            modelBuilder.Entity<Recipe>()
            .HasOne(r => r.User)
            .WithMany(u => u.Recipes);
        }
    }
}