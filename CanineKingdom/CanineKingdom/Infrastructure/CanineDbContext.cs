using CanineKingdom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CanineKingdom.Infrastructure
{
    public class CanineDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public CanineDbContext(DbContextOptions<CanineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ArticleReaction> ArticleReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Make sure AccountNumber is alternate key (unique)
            modelBuilder.Entity<ApplicationUser>()
                .HasAlternateKey(u => u.AccountNumber);

            // ArticleComment -> CommentReactions (cascade delete allowed here)
            //modelBuilder.Entity<ArticleComment>()
            //    .HasMany(c => c.Reactions)
            //    .WithOne(r => r.ArticleComment)
            //    .HasForeignKey(r => r.ArticleCommentId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //CommentReaction->ApplicationUser by AccountNumber
            //modelBuilder.Entity<CommentReaction>()
            //    .HasOne(r => r.User)
            //    .WithMany()
            //    .HasForeignKey(r => r.UserAccountNumber)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Remove duplicates: only one relation per FK!
        }

    }
}