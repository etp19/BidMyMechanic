using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Entities.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Engine { get; set; }
        public string Type { get; set; }
        public string Drive { get; set; }
    }
}
