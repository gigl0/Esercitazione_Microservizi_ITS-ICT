using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrestitiBibliotecaWebAPI.Models;

public partial class PrestitiBibliotecaContext : DbContext
{
    public PrestitiBibliotecaContext()
    {
    }

    public PrestitiBibliotecaContext(DbContextOptions<PrestitiBibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestito> Prestitos { get; set; }

    public virtual DbSet<Studente> Studentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {

        IConfigurationRoot configuration = new ConfigurationBuilder()

            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)

            .AddJsonFile("appsettings.json")

            .Build();



        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Codice).HasName("PK_Biblioteca_f");

            entity.Property(e => e.Codice).ValueGeneratedNever();
        });

        modelBuilder.Entity<Prestito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Prestito_1");
        });

        modelBuilder.Entity<Studente>(entity =>
        {
            entity.HasKey(e => e.Matricola).HasName("PK_Studenti");

            entity.Property(e => e.Matricola).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
