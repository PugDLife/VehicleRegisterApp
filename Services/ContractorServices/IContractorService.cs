using VehicleRegisterApp.Data.Models;

namespace VehicleRegisterApp.Services.ContractorServices
{
    public interface IContractorService
    {
        Task<List<Contractor>> GetAllAsync();
        Task<Contractor?> GetByIdAsync(Guid id);
        Task<Contractor> CreateAsync(Contractor contractor);
        Task<bool> DeleteAsync(Guid id);

        Task<Contractor> UpdateAsync(Guid? id, Contractor contractor);
    }
}
