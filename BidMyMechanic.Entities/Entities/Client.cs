using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Entities.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public IEnumerable<Bid> BidHistory { get; set; }
        public BidUser BidUser { get; set; }
    }
}
