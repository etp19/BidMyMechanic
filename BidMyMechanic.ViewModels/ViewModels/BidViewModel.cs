using BidMyMechanic.Entities.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BidMyMechanic.ViewModels.ViewModels
{
    public class BidViewModel
    {
        public int Id { get; set; } 
        [Required]
        public decimal Amount { get; set; }
        [MinLength(4)]
        public string Notes { get; set; }
        public Issue Issue { get; set; }
        public int UserId { get; set; }
        public DateTime BidTimePeriod { get; set; }
    }
}
