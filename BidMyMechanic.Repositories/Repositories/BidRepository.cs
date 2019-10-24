using System.Collections.Generic;
using System.Linq;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BidMyMechanic.Repositories.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly BidMyMechanicContext _dbContext;

        public BidRepository(BidMyMechanicContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Bid> GetAll()
        {
            return _dbContext.Bids
                .Include(issue => issue.Issue)
                .Include(objWithCar => objWithCar.Issue.Vehicle)
                .ToList();
        }
    }
}
