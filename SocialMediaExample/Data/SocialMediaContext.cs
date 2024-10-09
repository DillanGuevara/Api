using Microsoft.EntityFrameworkCore;
using SocialMediaExample.Entities;

namespace SocialMediaExample.Data
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public object Login { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<Login>()
                .ToTable("Login")
            .HasKey(l => l.IdLogin);

            modelBuilder.Entity<Post>()
                .ToTable("Post")
                .HasKey(p => p.IdPost);
        }
    }
}
