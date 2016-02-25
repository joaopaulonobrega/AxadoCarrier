using AxadoCarrier.Domain.Entities.Registers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxadoCarrier.Data.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AxadoCarrier") { }

        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Database.SetInitializer<AppContext>(null);
        }
    }
}
