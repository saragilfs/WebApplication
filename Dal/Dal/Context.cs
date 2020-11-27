using Model;
using System.Data.Entity;

namespace Dal
{
    public class Context : DbContext
    {

        #region DbSets

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<UsualDriver> UsualDrivers { get; set; }

        public DbSet<InfractionType> InfractionTypes { get; set; }

        public DbSet<Infraction> Infractions { get; set; }

        #endregion
    }
}
