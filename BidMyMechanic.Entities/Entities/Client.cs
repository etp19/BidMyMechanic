using System.Collections.Generic;

namespace BidMyMechanic.Entities.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public IEnumerable<Bid> BidHistory { get; set; }
        public IEnumerable<Issue> IssueHistory { get; set; }
        public BidUser BidUser { get; set; }
    }
}
