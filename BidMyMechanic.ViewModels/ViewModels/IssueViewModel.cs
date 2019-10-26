using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BidMyMechanic.ViewModels.ViewModels
{
    public class IssueViewModel
    {
        public int Id { get; set; }
        public string IssueType { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        [Required]
        public int IssueTrackingId { get; set; }
        public string IssueTrackingStatus { get; set; }
        public DateTime IssueTrackingStatusDateTime { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleYear { get; set; }


    }
}
