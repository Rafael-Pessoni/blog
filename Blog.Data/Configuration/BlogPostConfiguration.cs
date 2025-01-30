using Blog.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configuration;

public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Content).IsRequired();
        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasMany(c => c.Comments)
            .WithOne(bp => bp.BlogPost)
            .HasForeignKey(c => c.BlogPostId);
    }
}
