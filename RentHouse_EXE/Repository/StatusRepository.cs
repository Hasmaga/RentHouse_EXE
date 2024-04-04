using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly RentHouseDbContext _db;
        

        public StatusRepository(RentHouseDbContext db)
        {
            _db = db;            
        }

        // Create Status
        public async Task<bool> CreateStatusRepository(Status status)
        {
            try
            {
                await _db.Statuses.AddAsync(status);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }           
        }

        // Get All Status
        public async Task<List<Status>?> GetAllStatusRepository()
        {
            try
            {
                return await _db.Statuses.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        // Get Status By Id
        public async Task<Status?> GetStatusByIdRepository(Guid id)
        {
            try
            {
                return await _db.Statuses.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        // Get Status By Name
        public async Task<Status?> GetStatusByNameRepository(string statusName)
        {
            try
            {
                return await _db.Statuses.FirstOrDefaultAsync(s => s.StatusName == statusName);
            } catch (Exception)
            {
                throw;
            }
        }

        // Uodate Status
        public async Task<bool> UpdateStatusRepository(Status status)
        {
            try
            {
                _db.Statuses.Update(status);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
