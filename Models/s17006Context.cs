using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaAwesomeApi.Models
{
    public partial class s17006Context : DbContext
    {
        public s17006Context()
        {
        }

        public s17006Context(DbContextOptions<s17006Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Rodzaj> Rodzaj { get; set; }
        public virtual DbSet<Sklada> Sklada { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<SkladnikPizza> SkladnikPizza { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17006;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NrTelefonu)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdRodzajNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdRodzaj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Rodzaj");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Stanowisko)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Rodzaj>(entity =>
            {
                entity.HasKey(e => e.IdRodzaj)
                    .HasName("Rodzaj_pk");

                entity.Property(e => e.IdRodzaj).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Sklada>(entity =>
            {
                entity.HasKey(e => e.IdZlozenia)
                    .HasName("Sklada_pk");

                entity.Property(e => e.IdZlozenia).ValueGeneratedNever();

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Sklada)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sklada_Pracownik");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.Sklada)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sklada_Zamowienie");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SkladnikPizza>(entity =>
            {
                entity.HasKey(e => e.IdSkladnikPizza)
                    .HasName("SkladnikPizza_pk");

                entity.Property(e => e.IdSkladnikPizza).ValueGeneratedNever();

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.SkladnikPizza)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SkladnikPizza_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.SkladnikPizza)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SkladnikPizza_Skladnik");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
