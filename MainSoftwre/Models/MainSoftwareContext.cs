using System;
using MainSoftwre.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MainSoftwre.Models
{
    public partial class MainSoftwareContext : DbContext
    {
        public MainSoftwareContext()
        {
        }

        public MainSoftwareContext(DbContextOptions<MainSoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        public virtual DbSet<LibroDTo> LibroDTo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MainSoftware;Trusted_Connection=True; Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.ToTable("autores");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.ToTable("autores_has_libros");

                entity.Property(e => e.AutoresId).HasColumnName("autores_Id");

                entity.Property(e => e.LibrosIsbn).HasColumnName("libros_ISBN");

                entity.HasOne(d => d.Autores)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.AutoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autores_has_libros_autores");

                entity.HasOne(d => d.LibrosIsbnNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.LibrosIsbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autores_has_libros_libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.ToTable("editoriales");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.ToTable("libros");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.EditorialesId).HasColumnName("editoriales_Id");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Editoriales)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialesId)
                    .HasConstraintName("FK_libros_editoriales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
