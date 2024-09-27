using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DB;

public partial class MillionTestContext : DbContext
{
    public MillionTestContext()
    {
    }

    public MillionTestContext(DbContextOptions<MillionTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Owner> Owners { get; set; }
    public virtual DbSet<Property> Properties { get; set; }
    public virtual DbSet<PropertyImage> PropertyImages { get; set; }
    public virtual DbSet<PropertyTrace> PropertyTraces { get; set; }
    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.IdOwner).HasName("PK__Owner__D32618165B99C8CA");

            entity.ToTable("Owner");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.IdProperty).HasName("PK__Property__6C08B9A753ED1FCD");

            entity.ToTable("Property");

            entity.Property(e => e.IdProperty).HasColumnName("idProperty");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CodeInternal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdOwner).HasColumnName("idOwner");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Properties)
                .HasForeignKey(d => d.IdOwner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner_property");
        });

        modelBuilder.Entity<PropertyImage>(entity =>
        {
            entity.HasKey(e => e.IdPropertyImage).HasName("PK__Property__50B44F150B969B3D");

            entity.ToTable("PropertyImage");

            entity.Property(e => e.IdPropertyImage).HasColumnName("idPropertyImage");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.IdProperty).HasColumnName("idProperty");
            entity.Property(e => e.ImageFile).HasColumnName("imageFile");
            entity.Property(e => e.FileName).HasColumnName("FileName");
            entity.Property(e => e.ContentType).HasColumnName("ContentType");

            entity.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.PropertyImages)
                .HasForeignKey(d => d.IdProperty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_propertyImage_property");
        });

        modelBuilder.Entity<PropertyTrace>(entity =>
        {
            entity.HasKey(e => e.IdPropertyTrace).HasName("PK__Property__9252BB86AF7CC1A4");

            entity.ToTable("PropertyTrace");

            entity.Property(e => e.IdPropertyTrace).HasColumnName("idPropertyTrace");
            entity.Property(e => e.IdProperty).HasColumnName("idProperty");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Tax)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tax");
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.PropertyTraces)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("fk_propertyTrace_property");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C9822438B3D2");

            entity.ToTable("Users");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(4000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}