using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenDucThanh_2310900098.Models;

public partial class NguyenDucThanh2310900098Context : DbContext
{
    public NguyenDucThanh2310900098Context()
    {
    }

    public NguyenDucThanh2310900098Context(DbContextOptions<NguyenDucThanh2310900098Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NdtEmployee> NdtEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-S8D005FS\\SQLEXPRESS;Database=NguyenDucThanh_2310900098;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NdtEmployee>(entity =>
        {
            entity.HasKey(e => e.NdtEmpId).HasName("PK__NdtEmplo__3471481A00C99A13");

            entity.ToTable("NdtEmployee");

            entity.Property(e => e.NdtEmpId)
                .ValueGeneratedNever()
                .HasColumnName("ndtEmpId");
            entity.Property(e => e.NdtEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("ndtEmpLevel");
            entity.Property(e => e.NdtEmpName)
                .HasMaxLength(100)
                .HasColumnName("ndtEmpName");
            entity.Property(e => e.NdtEmpStartDate).HasColumnName("ndtEmpStartDate");
            entity.Property(e => e.NdtEmpStatus).HasColumnName("ndtEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
