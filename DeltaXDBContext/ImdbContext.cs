using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using deltax.imdb.Models;
namespace deltax.imdb.DeltaXDBContext
{
    public partial class ImdbContext : DbContext
    {
        public ImdbContext()
        {
        }

        public ImdbContext(DbContextOptions<ImdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActorsMapping> MovieActorsMapping { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:ImdbDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.ActorFirstName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ActorLastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.DateOfRelease).HasColumnType("datetime");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Plot)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PosterUrl)
                    .IsRequired()
                    .HasColumnName("PosterURL")
                    .IsUnicode(false);

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK__Movie__ProducerI__3F466844");
            });

            modelBuilder.Entity<MovieActorsMapping>(entity =>
            {
                entity.HasKey(e => e.MovieActorsId)
                    .HasName("PK__MovieAct__71A14400CF25E551");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActorsMapping)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__MovieActo__Actor__4316F928");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActorsMapping)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieActo__Movie__4222D4EF");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.Bio)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProducerFirstName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerLastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
