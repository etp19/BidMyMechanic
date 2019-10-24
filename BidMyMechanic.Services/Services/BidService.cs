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
    }
}
