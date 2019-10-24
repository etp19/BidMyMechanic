using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Services.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAllVehicles();
    }
}