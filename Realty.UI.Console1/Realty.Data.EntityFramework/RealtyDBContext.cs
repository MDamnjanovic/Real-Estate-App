using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Realty.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;

namespace Realty.Data.EntityFramework
{
    public class RealtyDBContext : DbContext
    {
        private static string ConnectionString
        {
            get
            {
                return "Server=DESKTOP-7HU06SQ; Database=RealtyDb; Integrated Security=True;";
                //return ConfigurationManager.AppSettings[]
                //return ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            }
        }

        public DbSet<RealtyEntities> Realty { get; set; }
        public DbSet<RealtyAddressEntities> RealtyAddress { get; set; }
        public DbSet<ResidentialAreaEntities> ResidentialArea { get; set; }
        public DbSet<MunicipalityEntities> Municipality { get; set; }
        public DbSet<CityEntities> City { get; set; }
        public DbSet<AgentClientEntities> AgentClient { get; set; }
        public DbSet<AgencyEntities> Agency { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var connString = root.GetConnectionString("RealtyUIMVCContext");
            optionsBuilder.UseSqlServer(connString);

        }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<RealtyDBContext>(options => options.UseSqlServer(ConnectionString));
        }

        public RealtyDBContext(DbContextOptions<RealtyDBContext> options)
            : base(options)
        { }

        public RealtyDBContext()
        {
        }
    }
}
