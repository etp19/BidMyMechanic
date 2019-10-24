using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Services.Interfaces
{
    public interface IIssueTrackingService
    {
        IEnumerable<IssueTracking> GetAll();
    }
}