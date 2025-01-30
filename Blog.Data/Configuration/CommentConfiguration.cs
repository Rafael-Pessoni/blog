using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
{
    public void Configure(EntityTypeBuilder<CommentModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasOne(c => c.BlogPost)
            .WithMany(bp => bp.Comments)
            .HasForeignKey(c => c.BlogPostId);
    }
}
