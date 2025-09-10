using VehicleRegisterApp.Data.Models;

namespace VehicleRegisterApp.Services.VehicleServices
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllByContractorIdAsync(Guid contractorId);
        Task<List<Vehicle>> GetAllAsync();
        Task<Vehicle?> GetByIdAsync(Guid id);
        Task<Vehicle> CreateAsync(Vehicle vehicle);
        Task<Vehicle> UpdateAsync(Guid? Id, Vehicle vehicle);
        Task<bool> DeleteAsync(Guid id);
    }
}
