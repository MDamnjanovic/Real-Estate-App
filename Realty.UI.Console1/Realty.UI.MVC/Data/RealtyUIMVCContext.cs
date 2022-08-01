using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Realty.Entities;

namespace Realty.UI.MVC.Data
{
    public class RealtyUIMVCContext : DbContext
    {
        public RealtyUIMVCContext (DbContextOptions<RealtyUIMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Realty.Entities.RealtyEntities> RealtyEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RealtyEntities>(entity => {
                entity.ToTable("Realty");
            });
        }
    }
}
