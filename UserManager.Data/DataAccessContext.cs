using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserManager.Data.Entities;

namespace UserManager.Data
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

        internal DbQuery<DbColonne> Colonne { get; set; }
        internal DbQuery<DbEmploye> Employe { get; set; }
        internal DbQuery<DbProfile> Profile { get; set; }
        internal DbQuery<DbProfileColonne> ProfileColonne { get; set; }
        internal DbQuery<DbUtilisateur> Utilisateur { get; set; }

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

            modelBuilder.Query<DbColonne>();
            modelBuilder.Query<DbEmploye>();
            modelBuilder.Query<DbProfile>();
            modelBuilder.Query<DbProfileColonne>();
            modelBuilder.Query<DbUtilisateur>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
