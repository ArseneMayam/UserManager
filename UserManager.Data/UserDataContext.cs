using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Data;

namespace UserManager.Data
{
    public class UserDataContext : DbContext
    {

        public UserDataContext(DbContextOptions<UserDataContext> options): base(options)
        {

        }

        //Create DBSets
       // internal DbQuery<DbUser> Users { get; set; }
        public DbSet<DbUser> Users { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>();
        }
    }
}
