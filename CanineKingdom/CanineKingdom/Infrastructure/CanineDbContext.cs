﻿using CanineKingdom.Models;
using Microsoft.EntityFrameworkCore;

namespace CanineKingdom.Infrastructure
{
    public class CanineDbContext : DbContext
    {
        public CanineDbContext(DbContextOptions<CanineDbContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
               .HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Cascade); // Allows cascading delete for articles
        }

    }
}
