using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Entities.Entities
{
    public class IssueTracking
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime StatusDateTime { get; set; }
    }
}
