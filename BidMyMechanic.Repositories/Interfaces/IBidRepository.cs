using System.Collections.Generic;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Repositories.Interfaces
{
    public interface IBidRepository
    {
        IEnumerable<Bid> GetAll();
        IEnumerable<Bid> GetBidsByUser(string userName);
        Bid GetBidById(int id);
        Issue GetBidRelateIssueById(int bidId);
        bool SaveEntity<T>(T model);
    }
}
