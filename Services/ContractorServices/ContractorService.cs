using Microsoft.EntityFrameworkCore;
using VehicleRegisterApp.Data;
using VehicleRegisterApp.Data.Models;

namespace VehicleRegisterApp.Services.ContractorServices
{
    public class ContractorService : IContractorService
    {
        private readonly DataBaseContext _dataBaseContext;
        public ContractorService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<Contractor> CreateAsync(Contractor contractor)
        {
            _dataBaseContext.Contractors.Add(contractor);
            await _dataBaseContext.SaveChangesAsync();
            return contractor;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var contractor = await _dataBaseContext.Contractors.FirstOrDefaultAsync(x => x.Id == id);
            if (contractor == null) return false;
            _dataBaseContext.Contractors.Remove(contractor);
            await _dataBaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Contractor>> GetAllAsync()
        {
            return await _dataBaseContext.Contractors.AsNoTracking().ToListAsync();
        }

        public async Task<Contractor?> GetByIdAsync(Guid id)
        {
            return await _dataBaseContext.Contractors.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Contractor> UpdateAsync(Guid? id, Contractor contractor)
        {
            var existingContrator = await _dataBaseContext.Contractors.FirstOrDefaultAsync(c => c.Id == id);
            if (existingContrator == null) return null;
            existingContrator.Email = contractor.Email;
            existingContrator.Name = contractor.Name;
            existingContrator.PhoneNumber = contractor.PhoneNumber;

            await _dataBaseContext.SaveChangesAsync();
            return existingContrator;
        }

    }
}
