using BidMyMechanic.Services.Interfaces;
using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;

namespace BidMyMechanic.Services.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        public IEnumerable<Bid> GetAll()
        {
            return _bidRepository.GetAll();
        }

        public Bid GetBidById(int id)
        {
            return _bidRepository.GetBidById(id);
        }

        public Issue GetBidRelateIssueById(int bidId)
        {
            return _bidRepository.GetBidRelateIssueById(bidId);
        }

        public IEnumerable<Bid> GetBidsByUser(string userName)
        {
            return _bidRepository.GetBidsByUser(userName);
        }

        public bool SaveEntity<T>(T model)
        {
           return _bidRepository.SaveEntity(model);
        }
    }
}
