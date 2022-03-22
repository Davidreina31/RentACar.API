using System;
using Microsoft.EntityFrameworkCore;

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


    }
}
