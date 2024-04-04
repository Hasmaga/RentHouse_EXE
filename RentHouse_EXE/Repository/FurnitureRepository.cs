using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class FurnitureRepository : IFurnitureRepository
    {
        private readonly RentHouseDbContext _context;

        public FurnitureRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFurnitureAsync(Furniture furniture)
        {
            try
            {
                await _context.Furnitures.AddAsync(furniture);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Furniture>> GetAllListFurnitureAsync()
        {
            try
            {
                return await _context.Furnitures.ToListAsync();
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Furniture?> GetFurnitureByIdAsync(Guid id)
        {
            try
            {
                return await _context.Furnitures.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
