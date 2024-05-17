﻿using api.Configuration;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
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
        }

        private static void ConfigurePosts(ModelBuilder builder)
        {
            builder.Entity<Post>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.Id).ValueGeneratedNever();

                b.Property(e => e.Text).HasMaxLength(StringLengths.PostMaxLength);
            });
        }

        private static void ConfigureUsers(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
