using BidMyMechanic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BidMyMechanic.Services.Interfaces
{
    public interface IBidService
    {
        IEnumerable<Bid> GetAllBids();
    }
}
