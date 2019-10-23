using System;
using BidMyMechanic.Entities;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BidMyMechanic.Services.Services;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Entities
{
    public class BidMyMechanicSeeder
    {
        private readonly BidMyMechanicContext _bidMyMechanicContext;
        private readonly IHostingEnvironment _hosting;
        public BidMyMechanicSeeder(BidMyMechanicContext bidMyMechanicContext, IHostingEnvironment hosting)
        {
            _bidMyMechanicContext = bidMyMechanicContext;
            _hosting = hosting;
        }

        public void Seed()
        {
            // Ensure Database exist, if not it will create it.
            _bidMyMechanicContext.Database.EnsureCreated();

            if (!_bidMyMechanicContext.Vehicles.Any())
            {
                // Need to create sample data for vehicles
                UtilSerializer serializer = new UtilSerializer();
                var filePath = Path.Combine(_hosting.ContentRootPath, "vehicle.json");
                IEnumerable<Vehicle> vehicleData = serializer.JSONDeserialize<Vehicle>(filePath);
                if (vehicleData.Any())
                {
                    _bidMyMechanicContext.AddRange(vehicleData);
                    _bidMyMechanicContext.SaveChanges();
                    var issueTracking = new IssueTracking() { Id = 1, Status = "Peding", StatusDateTime = DateTime.Now };
                    var issue = new Issue() { Id = 1, IssueTracking = issueTracking, IssueType = "Exterior", Notes = "Feed Data", Vehicle = vehicleData.First() };
                    var bid = new Bid() { Id = 1, Amount = 400, BidTimePeriod = DateTime.Now, Notes = "Feed Data", UserId = 1, Vehicle = vehicleData.First() };
                }

                
            }
        }
    }
}
