using Blog.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content).IsRequired().HasMaxLength(500);
        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasOne(c => c.BlogPost)
            .WithMany(bp => bp.Comments)
            .HasForeignKey(c => c.BlogPostId);
    }
}
