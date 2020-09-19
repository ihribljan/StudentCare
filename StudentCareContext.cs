using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp2
{
    public partial class StudentCareContext : DbContext
    {
        public StudentCareContext()
        {
        }

        public StudentCareContext(DbContextOptions<StudentCareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dvorane> Dvorane { get; set; }
        public virtual DbSet<Kolegiji> Kolegiji { get; set; }
        public virtual DbSet<Nastavnici> Nastavnici { get; set; }
        public virtual DbSet<NastavniciKolegiji> NastavniciKolegiji { get; set; }
        public virtual DbSet<ObliciNastave> ObliciNastave { get; set; }
        public virtual DbSet<Ocjene> Ocjene { get; set; }
        public virtual DbSet<Provjere> Provjere { get; set; }
        public virtual DbSet<Rasporedi> Rasporedi { get; set; }
        public virtual DbSet<Studenti> Studenti { get; set; }
        public virtual DbSet<StudentiKolegiji> StudentiKolegiji { get; set; }
        public virtual DbSet<TipoviProvjera> TipoviProvjera { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IVAN-PC\\SQLEXPRESS;Database=StudentCare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dvorane>(entity =>
            {
                entity.Property(e => e.Kat)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Krilo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Zgrada)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kolegiji>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Opis).HasColumnType("text");
            });

            modelBuilder.Entity<Nastavnici>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Konzultacije)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dvorane)
                    .WithMany(p => p.Nastavnici)
                    .HasForeignKey(d => d.DvoraneId)
                    .HasConstraintName("FK__Nastavnic__Dvora__2739D489");
            });

            modelBuilder.Entity<NastavniciKolegiji>(entity =>
            {
                entity.HasOne(d => d.Kolegiji)
                    .WithMany(p => p.NastavniciKolegiji)
                    .HasForeignKey(d => d.KolegijiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nastavnic__Koleg__6A30C649");

                entity.HasOne(d => d.Nastavnici)
                    .WithMany(p => p.NastavniciKolegiji)
                    .HasForeignKey(d => d.NastavniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nastavnic__Nasta__693CA210");
            });

            modelBuilder.Entity<ObliciNastave>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.Property(e => e.Bodovi)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Napomena).HasColumnType("text");
            });

            modelBuilder.Entity<Provjere>(entity =>
            {
                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ocjena)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.HasOne(d => d.Dvorane)
                    .WithMany(p => p.Provjere)
                    .HasForeignKey(d => d.DvoraneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Provjere__Dvoran__72C60C4A");

                entity.HasOne(d => d.Kolegiji)
                    .WithMany(p => p.Provjere)
                    .HasForeignKey(d => d.KolegijiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Provjere__Kolegi__71D1E811");

                entity.HasOne(d => d.TipoviProvjera)
                    .WithMany(p => p.Provjere)
                    .HasForeignKey(d => d.TipoviProvjeraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Provjere__Tipovi__73BA3083");
            });

            modelBuilder.Entity<Rasporedi>(entity =>
            {
                entity.Property(e => e.DatumDo).HasColumnType("datetime");

                entity.Property(e => e.DatumOd).HasColumnType("datetime");

                entity.Property(e => e.Napomena).HasColumnType("text");

                entity.HasOne(d => d.Dvorane)
                    .WithMany(p => p.Rasporedi)
                    .HasForeignKey(d => d.DvoraneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rasporedi__Dvora__7A672E12");

                entity.HasOne(d => d.Kolegiji)
                    .WithMany(p => p.Rasporedi)
                    .HasForeignKey(d => d.KolegijiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rasporedi__Koleg__787EE5A0");

                entity.HasOne(d => d.ObliciNastave)
                    .WithMany(p => p.Rasporedi)
                    .HasForeignKey(d => d.ObliciNastaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rasporedi__Oblic__797309D9");
            });

            modelBuilder.Entity<Studenti>(entity =>
            {
                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbag)
                    .IsRequired()
                    .HasColumnName("JMBAG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentiKolegiji>(entity =>
            {
                entity.HasOne(d => d.Kolegiji)
                    .WithMany(p => p.StudentiKolegiji)
                    .HasForeignKey(d => d.KolegijiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentiK__Koleg__17036CC0");

                entity.HasOne(d => d.Studenti)
                    .WithMany(p => p.StudentiKolegiji)
                    .HasForeignKey(d => d.StudentiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentiK__Stude__160F4887");
            });

            modelBuilder.Entity<TipoviProvjera>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
