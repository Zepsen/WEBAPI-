using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Companies> Companies { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-9K6B7B5\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=ZEPSENHOME\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
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
