using BidMyMechanic.Entities;
using BidMyMechanic.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BidMyMechanic.Services.Services
{
    public class BidService : IBidService
    {
        public IEnumerable<Bid> GetAllBids()
        {
            return new List<Bid>();
        }
    }
}
