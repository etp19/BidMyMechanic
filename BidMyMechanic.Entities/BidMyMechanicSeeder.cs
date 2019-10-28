using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BidMyMechanic.Services.Services;
using BidMyMechanic.Entities.Entities;
using BidMyMechanic.Entities.Utilities.enums;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BidMyMechanic.Entities
{
    public class BidMyMechanicSeeder
    {
        private readonly BidMyMechanicContext _bidMyMechanicContext;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<BidUser> _userManager;

        public BidMyMechanicSeeder(BidMyMechanicContext bidMyMechanicContext, IHostingEnvironment hosting, UserManager<BidUser> userManager)
        {
            _bidMyMechanicContext = bidMyMechanicContext;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            // Ensure Database exist, if not it will create it.
            _bidMyMechanicContext.Database.EnsureCreated();

            BidUser user = await _userManager.FindByEmailAsync("torres@BidMyMechanic.com");
            if (user == null)
            {
                user = new BidUser
                {
                    FirstName = "Eduardo",
                    LastName = "Torres",
                    Address = "temp location",
                    State = "Michigan",
                    City = "Lansing",
                    ZipCode = "44554",
                    Type = BaseEnums.UserType.Client,
                    Email = "torres@BidMyMechanic.com",
                    UserName = "torres@BidMyMechanic.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success) throw new InvalidOperationException("Could not create new user in seeder"); 
                
            }

            if (!_bidMyMechanicContext.Vehicles.Any())
            {
                // Need to create sample data for vehicles
                UtilSerializer serializer = new UtilSerializer();
                var filePath = Path.Combine(_hosting.ContentRootPath, "vehicles.json");
                IEnumerable<Vehicle> vehicleData = serializer.JSONDeserialize<Vehicle>(filePath);
                if (vehicleData.Any())
                {
                    List<Issue> IssueList = new List<Issue>();
                    List<Bid> BidList = new List<Bid>();
                    _bidMyMechanicContext.AddRange(vehicleData);
                    var issueTracking = new IssueTracking() { Status = "Pending", StatusDateTime = DateTime.Now };
                    var issue = new Issue() { IssueTracking = issueTracking, IssueType = "Exterior", Notes = "Door Damage", Vehicle = vehicleData.First(), Amount = 500, BidUser = user};
                    var bid = new Bid() { Amount = 400, BidTimePeriod = DateTime.Now, 
                        Notes = "I can do the job for ", BidUser = user,
                        Issue = issue , IncludeParts = BaseEnums.IncludeParts.No,
                        Status = BaseEnums.BidStatus.Open
                    };
                    IssueList.Add(issue);
                    BidList.Add(bid);
                    var client = new Client() { BidUser = user, IssueHistory = IssueList, BidHistory = BidList};
                    _bidMyMechanicContext.IssueTrackings.Add(issueTracking);
                    _bidMyMechanicContext.Issues.Add(issue);
                    _bidMyMechanicContext.Bids.Add(bid);
                    _bidMyMechanicContext.Clients.Add(client);
                    _bidMyMechanicContext.SaveChanges();
                }

                
            }
        }
    }
}
