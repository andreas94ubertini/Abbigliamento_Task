using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Abbigliamento_Task.Models;

public partial class AbbigliamentoTaskContext : DbContext
{
    public AbbigliamentoTaskContext()
    {
    }

    public AbbigliamentoTaskContext(DbContextOptions<AbbigliamentoTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<OrdineVariazione> OrdineVariaziones { get; set; }

    public virtual DbSet<Prezzo> Prezzos { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    public virtual DbSet<Variazione> Variaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-11\\SQLEXPRESS;Database=Abbigliamento_Task;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C0202D25EBA2");

            entity.HasIndex(e => e.NomeCategoria, "UQ__Categori__8FC1D7372332D135").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.NomeCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomeCategoria");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E54FB8C805");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataEmissione).HasColumnName("dataEmissione");
            entity.Property(e => e.IsArrivato).HasColumnName("isArrivato");
            entity.Property(e => e.NumeroOrdine)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroOrdine");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Ordine__utenteRI__4AB81AF0");
        });

        modelBuilder.Entity<OrdineVariazione>(entity =>
        {
            entity.HasKey(e => e.OrdineVariazioneId).HasName("PK__Ordine_V__26E9E05B4BAE214A");

            entity.ToTable("Ordine_Variazione");

            entity.Property(e => e.OrdineVariazioneId).HasColumnName("ordine_variazioneID");
            entity.Property(e => e.OrdineRif).HasColumnName("ordineRIF");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.OrdineRifNavigation).WithMany(p => p.OrdineVariaziones)
                .HasForeignKey(d => d.OrdineRif)
                .HasConstraintName("FK__Ordine_Va__ordin__4D94879B");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.OrdineVariaziones)
                .HasForeignKey(d => d.VariazioneRif)
                .HasConstraintName("FK__Ordine_Va__varia__4E88ABD4");
        });

        modelBuilder.Entity<Prezzo>(entity =>
        {
            entity.HasKey(e => e.PrezzoId).HasName("PK__Prezzo__B096F6D78BDDCE23");

            entity.ToTable("Prezzo");

            entity.Property(e => e.PrezzoId).HasColumnName("prezzoID");
            entity.Property(e => e.DataFine).HasColumnName("dataFine");
            entity.Property(e => e.DataInizio).HasColumnName("dataInizio");
            entity.Property(e => e.PrezzoPieno)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("prezzoPieno");
            entity.Property(e => e.PrezzoSconto)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("prezzoSconto");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.Prezzos)
                .HasForeignKey(d => d.VariazioneRif)
                .HasConstraintName("FK__Prezzo__variazio__46E78A0C");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB659750036FA16");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.ImgDue)
                .HasColumnType("text")
                .HasColumnName("imgDue");
            entity.Property(e => e.ImgUno)
                .HasColumnType("text")
                .HasColumnName("imgUno");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modello)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modello");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .HasConstraintName("FK__Prodotto__catego__3E52440B");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C2253E9838E3C");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.NomeUtente, "UQ__Utente__8A3C9FDF4C8F1373").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Utente__AB6E6164334D0DD4").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.NomeUtente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomeUtente");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5A623A70CB");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.Qt).HasColumnName("qt");
            entity.Property(e => e.Taglia)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Variazion__prodo__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
