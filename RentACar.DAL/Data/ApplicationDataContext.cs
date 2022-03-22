using System;
using Microsoft.EntityFrameworkCore;
using RentACar.MODELS;

namespace RentACar.DAL.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext()
        {
        }

        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=RentACar;User Id=SA;Password=P@ssword1;");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Desktop> Desktops { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
