using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Realty.Data.EntityFramework1
{
    public partial class RealtyDataEF : DbContext
    {
        public RealtyDataEF()
            : base("name=RealtyDataEF")
        {
        }

        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<AgentClient> AgentClients { get; set; }
        public virtual DbSet<ApartmentProperty> ApartmentProperties { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<HouseProperty> HouseProperties { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Realty> Realties { get; set; }
        public virtual DbSet<RealtyAddress> RealtyAddresses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<ResidentialArea> ResidentialAreas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserAgentChat> UserAgentChats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentClient>()
                .HasMany(e => e.UserAgentChats)
                .WithOptional(e => e.AgentClient)
                .HasForeignKey(e => e.RecieverId);

            modelBuilder.Entity<AgentClient>()
                .HasMany(e => e.UserAgentChats1)
                .WithOptional(e => e.AgentClient1)
                .HasForeignKey(e => e.SenderId);

            modelBuilder.Entity<ApartmentProperty>()
                .Property(e => e.NumberOfRooms)
                .HasPrecision(1, 1);

            modelBuilder.Entity<HouseProperty>()
                .Property(e => e.NumberOfRooms)
                .HasPrecision(1, 1);

            modelBuilder.Entity<Realty>()
                .Property(e => e.Price)
                .HasPrecision(9, 0);
        }
    }
}
