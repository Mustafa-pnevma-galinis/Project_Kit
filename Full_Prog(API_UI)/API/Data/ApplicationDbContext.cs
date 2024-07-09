
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.Net;
using System.Xml;
using WebApplication1.Model.Domain;
using WebApplication1.Model.Externals;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Governorate> Governorates { get; set; }

       public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure triggers for the Addresses table
            modelBuilder.Entity<Addresses>().ToTable(tb => tb.HasTrigger("Count_Users"));
        }
    }
}
