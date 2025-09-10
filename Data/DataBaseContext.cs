using Microsoft.EntityFrameworkCore;
using VehicleRegisterApp.Data.Models;

namespace VehicleRegisterApp.Data
{
    public class DataBaseContext : DbContext
    {
       public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {

    }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
