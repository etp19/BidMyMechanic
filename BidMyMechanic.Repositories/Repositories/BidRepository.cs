using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BidMyMechanic.Entities;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BidMyMechanic.Repositories.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly BidMyMechanicContext _dbContext;
        private readonly ILogger<BidRepository> _logger;
        private readonly UserManager<BidUser> _userManager;

        public BidRepository(BidMyMechanicContext dbContext, ILogger<BidRepository> logger, UserManager<BidUser> userManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userManager = userManager;
        }

        public IEnumerable<Bid> GetAll()
        {
            return _dbContext.Bids
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.IssueTracking)
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.Vehicle)
                .ToList();
        }

        public IEnumerable<Bid> GetBidsByUser(string userName)
        {
            return _dbContext.Bids
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.IssueTracking)
                .Include(issue => issue.Issue).ThenInclude(vehicle => vehicle.Vehicle)
                .Where(info => info.BidUser.UserName == userName)
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
            var issue = _dbContext.Bids.Select(x => x.Issue).FirstOrDefault(o => o.Id == bidId);
            if (issue != null)
            {
                var completeIssue = _dbContext.Issues.Where(x => x.Id == issue.Id)
                    .Include(car => car.Vehicle)
                    .Include(issueTrack => issueTrack.IssueTracking)
                    .FirstOrDefault();
                return completeIssue;
            }
            else return null;
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
