using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Entities.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string IssueType { get; set; }
        public decimal Amount { get; set; }
        public Vehicle Vehicle { get; set; }
        public IssueTracking IssueTracking { get; set; }
        public string Notes { get; set; }
    }
}
