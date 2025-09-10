using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using VehicleRegisterApp.Data;
using VehicleRegisterApp.Data.Models;

namespace VehicleRegisterApp.Services.VehicleServices
{
    public class VehicleService : IVehicleService
    {
        private readonly DataBaseContext _dataBaseContext;

        public VehicleService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            _dataBaseContext.Vehicles.Add(vehicle);
            await _dataBaseContext.SaveChangesAsync();
            return vehicle;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var vehicle = _dataBaseContext.Vehicles.FirstOrDefault(x => x.Id == id);
            if (vehicle == null) return false;
            _dataBaseContext.Vehicles.Remove(vehicle);
            await _dataBaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _dataBaseContext.Vehicles.AsNoTracking().ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllByContractorIdAsync(Guid contractorId)
        {
           return await _dataBaseContext.Vehicles.Where(c => c.ContractorId == contractorId).ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _dataBaseContext.Vehicles.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Vehicle> UpdateAsync(Guid? Id, Vehicle vehicle)
        {
            var existingVehicle = await _dataBaseContext.Vehicles.FirstOrDefaultAsync(c => c.Id == Id);
            if (existingVehicle == null) return null;
            existingVehicle.Type = vehicle.Type;
            existingVehicle.RegNumber = vehicle.RegNumber;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Weight = vehicle.Weight;

            await _dataBaseContext.SaveChangesAsync();
            return existingVehicle;
        }
    }
}
