using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BidMyMechanic.Entities
{
    class BidMyMechanicSeeder
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
                // Need to create sample data
                var filePath = Path.Combine();
            }
        }
    }
}
