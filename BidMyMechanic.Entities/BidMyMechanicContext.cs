using BidMyMechanic.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BidMyMechanic.Entities
{
    public class BidMyMechanicContext: DbContext
    {
        public BidMyMechanicContext(DbContextOptions<BidMyMechanicContext> options) : base(options) { }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<IssueTracking> IssueTrackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class BidMyMechanicDbContextFactory : IDesignTimeDbContextFactory<BidMyMechanicContext>
    {
        public BidMyMechanicContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../BidMyMechanic/config.json").Build();
            var builder = new DbContextOptionsBuilder<BidMyMechanicContext>();
            var connectionString = configuration.GetConnectionString("BidMyMechanicConnectionStringLocal");
            builder.UseSqlServer(connectionString);
            return new BidMyMechanicContext(builder.Options);
        }
    }
}
