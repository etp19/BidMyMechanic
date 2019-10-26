using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Entities.Utilities.enums
{
    public class BaseEnums
    {
        public enum UserType
        {
            Buyer,
            Supplier,
            Employee
        }

        public enum BidStatus
        {
            Open,
            Reviewing,
            Pending,
            Close
        }

        public enum IncludeParts
        {
            Yes,
            No,
            NotApplicable
        }
    }
}
