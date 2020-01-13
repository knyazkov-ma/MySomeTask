using MySomeTask.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MySomeTask.DataBase
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Location> Locations { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();            

        }
    }
}
