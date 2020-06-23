using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserManager.Api
{
    public partial class SecondAccessContext : DbContext
    {
        public SecondAccessContext()
        {
        }

        public SecondAccessContext(DbContextOptions<SecondAccessContext> options)
            : base(options)
        {
        }

        public virtual DbQuery<Colonne> Colonne { get; set; }
        public virtual DbQuery<Profil> Profil { get; set; }
        public virtual DbQuery<ProfileColonne> ProfileColonne { get; set; }
        public virtual DbQuery<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CA-L1B00SQ2\\MSSQLSERVER01;Database=rhbdReplicate;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Colonne>();

            modelBuilder.Entity<Profil>();

            modelBuilder.Entity<ProfileColonne>();

            modelBuilder.Entity<User>();

            modelBuilder.HasSequence("SEQUENCE_1");
        }
    }
}
