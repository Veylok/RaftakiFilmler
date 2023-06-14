using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServicesV7.DBModels;

public partial class FilmlerContext : DbContext
{
    public FilmlerContext()
    {
    }

    public FilmlerContext(DbContextOptions<FilmlerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-4KPO4KL;Initial Catalog=Filmler;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.Property(e => e.FilmExplanation).HasMaxLength(500);
            entity.Property(e => e.FilmName).HasMaxLength(50);
            entity.Property(e => e.FilmProduction).HasMaxLength(50);
            entity.Property(e => e.FilmResimLinki).HasMaxLength(500);


            entity.HasOne(d => d.FilmTypeNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.FilmType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Films_Type");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
