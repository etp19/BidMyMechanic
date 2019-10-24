using System.Collections.Generic;
using BidMyMechanic.Entities.Entities;

namespace BidMyMechanic.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAllVehicles();
        IEnumerable<Vehicle> GetVehiclesByMake(string vehicleMake);
        IEnumerable<Vehicle> GetVehiclesByModel(string vehicleModel);
        IEnumerable<Vehicle> GetVehiclesByYear(string vehicleYear);
        Vehicle GetVehicleById(int vehicleId);
    }
}