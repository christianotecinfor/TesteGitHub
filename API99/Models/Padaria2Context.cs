using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API99.Models;

public partial class Padaria2Context : DbContext
{
    public Padaria2Context()
    {
    }

    public Padaria2Context(DbContextOptions<Padaria2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SrRodrigues;Database=Padaria2;User Id=sa;Password=senha@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("IdPadaria");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Idade).HasColumnName("idade");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
