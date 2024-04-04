using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model.Provinces;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class LocationRepository(RentHouseDbContext context) : ILocationRepository
    {
        private readonly RentHouseDbContext _context = context;

        public async Task<IEnumerable<Provinces>> GetAllCityRepository()
        {
            try
            {
                return await _context.Provinces.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
                
        }

        public async Task<IEnumerable<Districts>> GetAllDistrictByCityIdRepository(int cityId)
        {
            try
            {
                return await _context.Districts.Where(x => x.Province_code == cityId.ToString()).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Wards>> GetAllWardByDistrictIdRepository(int districtId)
        {
            try
            {
                return await _context.Wards.Where(x => x.District_code == districtId.ToString()).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Provinces?> GetCityByIdAsync(string cityId)
        {
            try
            {
                return await _context.Provinces.FirstOrDefaultAsync(x => x.Code == cityId);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Districts?> GetDistrictByIdAsync(string districtId)
        {
            try
            {
                return await _context.Districts.FirstOrDefaultAsync(x => x.Code == districtId);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Wards?> GetWardByIdAsync(string wardId)
        {
            try
            {
                return await _context.Wards.FirstOrDefaultAsync(x => x.Code == wardId);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
