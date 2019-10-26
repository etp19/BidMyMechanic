using BidMyMechanic.Entities.Entities;
using System;
using BidMyMechanic.Entities.Utilities.enums;

namespace BidMyMechanic.Entities.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public Issue Issue { get; set; }
        public BidUser BidUser { get; set; }
        public DateTime BidTimePeriod { get; set; }
        public BaseEnums.BidStatus Status { get; set; }
        public BidUser WinnerId { get; set; }
        public DateTime WinDate { get; set; }
    }
}
