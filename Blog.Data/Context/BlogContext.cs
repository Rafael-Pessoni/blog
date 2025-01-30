using Blog.Core.Entities;
using Blog.Data.Configuration;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Context;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {

    }

    public DbSet<BlogPostModel> BlogPosts { get; set; }
    public DbSet<CommentModel> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options =>
        {
            options.CommandTimeout(60);
        });

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
