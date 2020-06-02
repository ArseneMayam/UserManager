using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserManager.Data.Entities;

namespace UserManager.Api
{
    public partial class DataAccessContext : DbContext
    {
        public DataAccessContext()
        {
        }

        public DataAccessContext(DbContextOptions<DataAccessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbColonne> Colonne { get; set; }
        public virtual DbSet<DbEmploye> Employe { get; set; }
        public virtual DbSet<DbProfile> Profile { get; set; }
        public virtual DbSet<DbProfileColonne> ProfileColonne { get; set; }
        public virtual DbSet<DbUtilisateur> Utilisateur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CA-L1B00SQ2\\MSSQLSERVER01;Database=rhbd;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DbColonne>(entity =>
            {
                entity.ToTable("colonne");

                entity.Property(e => e.ColonneId)
                    .HasColumnName("colonne_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<DbEmploye>(entity =>
            {
                entity.ToTable("employe");

                entity.Property(e => e.EmployeId)
                    .HasColumnName("employe_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeEmpl).HasColumnName("code_empl");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasColumnName("matricule")
                    .HasMaxLength(10);

                entity.Property(e => e.Nas).HasColumnName("nas");

                entity.Property(e => e.Natioanlite)
                    .IsRequired()
                    .HasColumnName("natioanlite")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rib)
                    .IsRequired()
                    .HasColumnName("rib")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tin)
                    .IsRequired()
                    .HasColumnName("tin")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<DbProfile>(entity =>
            {
                entity.ToTable("profile");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");
            });

            modelBuilder.Entity<DbProfileColonne>(entity =>
            {
                entity.HasKey(e => new { e.ProfileId, e.ColonneId })
                    .HasName("profileColonne_id");

                entity.ToTable("profileColonne");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.ColonneId).HasColumnName("colonne_id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DbUtilisateur>(entity =>
            {
                entity.ToTable("utilisateur");

                entity.Property(e => e.UtilisateurId)
                    .HasColumnName("utilisateur_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
