using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Entities.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Experience { get; set; }
        public string Reviews { get; set; }
        public BidUser BidUser { get; set; }
    }
}
