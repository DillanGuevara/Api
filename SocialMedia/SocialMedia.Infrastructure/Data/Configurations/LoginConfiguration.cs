using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumerations;
using System;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {

            builder.ToTable("Login");

            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.IdSecurity)
                .HasColumnName("IdSecurity");

            builder.Property(e => e.User)
                .HasColumnName("User")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Role)
                .HasColumnName("Role")
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion(
                 x => x.ToString(),
                 x => (RoleType)Enum.Parse(typeof(RoleType), x)
                );
        }
    }
}
