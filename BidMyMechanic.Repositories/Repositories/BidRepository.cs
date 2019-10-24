using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Repositories.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly BidMyMechanicContext _dbContext;
        private readonly ILogger<BidRepository> _logger;

        public BidRepository(BidMyMechanicContext dbContext, ILogger<BidRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public IEnumerable<Bid> GetAll()
        {
            return _dbContext.Bids
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.IssueTracking)
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.Vehicle)
                .ToList();
        }

        public Bid GetBidById(int id)
        {
            return _dbContext.Bids.Where(x => x.Id == id)
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.IssueTracking)
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.Vehicle)
                .FirstOrDefault();
        }

        public Issue GetBidRelateIssueById(int bidId)
        {
            return _dbContext.Bids.Select(x => x.Issue)
                .FirstOrDefault(x => x.Id == bidId);
        }

        public bool SaveEntity<T>(T model)
        {
            try
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to save to database: {error}");
                return false;
            }
            
        }
    }
}
