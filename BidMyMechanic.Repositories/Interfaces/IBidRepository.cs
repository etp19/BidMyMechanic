using System.Collections.Generic;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Repositories.Interfaces
{
    public interface IBidRepository
    {
        IEnumerable<Bid> GetAll();
    }
}
