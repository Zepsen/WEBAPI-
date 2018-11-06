using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyDescriptions> CompanyDescriptions { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9K6B7B5\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Server=ZEPSENHOME\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
        }

        /// <summary>
        /// Fluent 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
