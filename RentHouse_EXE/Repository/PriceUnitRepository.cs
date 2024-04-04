using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class PriceUnitRepository : IPriceUnitRepository
    {
        private readonly RentHouseDbContext _context;
        
        public PriceUnitRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePriceUnitAsync(PriceUnit priceUnit)
        {
            try
            {
                await _context.PriceUnits.AddAsync(priceUnit);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PriceUnit>> GetAllPriceUnitsAsync()
        {
            try
            {
                return await _context.PriceUnits.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<PriceUnit?> GetPriceUnitByIdAsync(Guid id)
        {
            try
            {
                return await _context.PriceUnits.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
