using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataStore
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() { }
        public VehicleContext(DbContextOptions<VehicleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasKey(entity => entity.ID);
            modelBuilder.Entity<Model>().HasKey(entity => entity.ID);
            modelBuilder.Entity<Color>().HasKey(entity => entity.ID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
