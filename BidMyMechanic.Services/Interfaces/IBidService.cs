using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Services.Interfaces
{
    public interface IBidService
    {
        IEnumerable<Bid> GetAll();
        Bid GetBidById(int id);
        Issue GetBidRelateIssueById(int bidId);
        IEnumerable<Bid> GetBidsByUser(string userName);
        bool SaveEntity<T>(T model);
    }
}
