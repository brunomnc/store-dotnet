using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using meetapp_dotnet.Domain.Models;
namespace meetapp_dotnet.Persistence.Contexts
{
  public partial class meetappContext : DbContext
  {
    public meetappContext()
    {
    }

    public meetappContext(DbContextOptions<meetappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5454;Database=meetapp;Username=postgres;Password=docker");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

      modelBuilder.Entity<Products>(entity =>
      {
        entity.ToTable("products");

        entity.HasIndex(e => e.Code)
                  .HasName("products_code_key")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Amount)
                  .HasColumnName("amount")
                  .HasDefaultValueSql("0");

        entity.Property(e => e.Code).HasColumnName("code");

        entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasColumnType("timestamptz");

        entity.Property(e => e.Description).HasColumnName("description");

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnName("name");

        entity.Property(e => e.Price).HasColumnName("price");

        entity.Property(e => e.UpdatedAt)
                  .HasColumnName("updated_at")
                  .HasColumnType("timestamptz");
      });

      modelBuilder.Entity<Users>(entity =>
      {
        entity.ToTable("users");

        entity.HasIndex(e => e.Email)
                  .HasName("users_email_key")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Age).HasColumnName("age");

        entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasColumnType("timestamptz");

        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasColumnName("email");

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnName("name");

        entity.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasColumnName("password_hash");

        entity.Property(e => e.Provider)
                  .IsRequired()
                  .HasColumnName("provider")
                  .HasDefaultValueSql("false");

        entity.Property(e => e.UpdatedAt)
                  .HasColumnName("updated_at")
                  .HasColumnType("timestamptz");
      });
    }
  }
}
