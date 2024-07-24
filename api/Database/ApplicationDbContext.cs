using api.Models;
using api.Shared;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigurePosts(builder);
            ConfigureUsers(builder);
            ConfigureFollows(builder);
        }

        private static void ConfigurePosts(ModelBuilder builder)
        {
            builder.Entity<Post>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.Id).ValueGeneratedNever();

                b.Property(e => e.UserId).ValueGeneratedNever();

                b.Property(e => e.Text).HasMaxLength(Post.TextMaxLength);
            });
        }

        private static void ConfigureUsers(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.Id).ValueGeneratedNever();

                b.Property(e => e.EmailAddress).HasMaxLength(StringLengths.MediumString);
            });
        }

        private static void ConfigureFollows(ModelBuilder builder)
        {
            builder.Entity<Follow>(b =>
            {
                b.HasKey(e => new { e.FollowerId, e.FollowedUserId });

                b.Property(e => e.FollowerId).ValueGeneratedNever();
                b.Property(e => e.FollowedUserId).ValueGeneratedNever();
            });
        }
    }
}
