using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>, IDesignTimeDbContextFactory<ApplicationContext>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server=DESKTOP-9K6B7B5\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
//            //optionsBuilder.UseSqlServer("Server=ZEPSENHOME\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
//        }

        /// <summary>
        /// Fluent 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(i => i.ApplicationUser)
                .WithOne(i => i.User)
                .HasForeignKey<User>(i => i.UserIdentityId);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-9K6B7B5\\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
