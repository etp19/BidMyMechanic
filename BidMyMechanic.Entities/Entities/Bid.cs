using BidMyMechanic.Entities.Entities;
using System;

namespace BidMyMechanic.Entities.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public Issue Issue { get; set; }
        public int UserId { get; set; }
        public DateTime BidTimePeriod { get; set; }
    }
}
