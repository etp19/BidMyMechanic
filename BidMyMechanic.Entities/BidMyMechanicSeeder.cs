using System;
using BidMyMechanic.Entities;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BidMyMechanic.Services.Services;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Entities.Utilities;

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
            _bidMyMechanicContext.Database.EnsureCreated();

            if (_bidMyMechanicContext.Bids.Any())
            {
                // Need to create sample data for bids
                var filePath = Path.Combine();
            }
            if (!_bidMyMechanicContext.Vehicles.Any())
            {
                // Need to create sample data for vehicles
                UtilSerializer xMLSerializer = new UtilSerializer();
                var filePath = Path.Combine(_hosting.ContentRootPath, "vehicles.csv");
                //var xmlInputData = File.ReadAllText(file);
                IEnumerable <VehicleRawFromCSV> extractVehicleData = xMLSerializer.CSVDeserialize<VehicleRawFromCSV>(filePath);
            }
        }
    }
}
