using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CommentId")
                .ValueGeneratedNever();

            builder.Property(e => e.PostId)
                .HasColumnName("PostId")
                .ValueGeneratedNever();

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedNever();

            builder.Property(e => e.IsActive)
                .HasColumnName("IsActive");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comment)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Comment_Post");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comment)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User");
        }
    }
}
