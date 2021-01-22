using System;
using AssetTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Data
{
    public class AssetContext: DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Mobile> Mobiles{ get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer("Server = 127.0.0.1,1433; Initial Catalog = Assets;User Id = sa; Password = myPassw0rd;  Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");


        }
    }
}
