using System;
using System.Collections.Generic;
using System.Text;
using BidMyMechanic.Entities.Utilities.enums;
using Microsoft.AspNetCore.Identity;

namespace BidMyMechanic.Entities.Entities
{
    public class BidUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public BaseEnums.UserType Type { get; set; }
    }
}
