using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class TypeRealEstateRepository : ITypeRealEstateRepository
    {
        private readonly RentHouseDbContext _context;

        public TypeRealEstateRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTypeRealEstateAsync(TypeRealEstate typeRealEstate)
        {
            try
            {
                await _context.TypeRealEstates.AddAsync(typeRealEstate);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TypeRealEstate>> GetListTypeRealEstateAsync()
        {
            try
            {
                return await _context.TypeRealEstates.ToListAsync();
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TypeRealEstate?> GetTypeRealEstateByIdAsync(Guid id)
        {
            try
            {
                return await _context.TypeRealEstates.FindAsync(id);
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TypeRealEstate?> GetTypeRealEstateByNameAsync(string Name)
        {
            try
            {
                return await _context.TypeRealEstates.FirstOrDefaultAsync(x => x.Name == Name);
            } 
            catch (Exception)
            {
                throw;
            }
        }
    }
}
