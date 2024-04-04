using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class RoleRepository(RentHouseDbContext db) : IRoleRepository
    {
        private readonly RentHouseDbContext _db = db;       

        public async Task<bool> CreateRoleRepository(Role role)
        {
            try
            {
                await _db.Roles.AddAsync(role);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Role>?> GetAllRoleRepository()
        {
            try
            {
                return await _db.Roles.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Role?> GetRoleByIdRepository(Guid id)
        {
            try
            {
                return await _db.Roles.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Role?> GetRoleByNameRepository(string roleName)
        {
            try 
            {
                return await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            } catch (Exception)
            {
                throw;
            }            
        }

        public async Task<bool> UpdateRoleRepository(Role role)
        {
            try
            {
                _db.Roles.Update(role);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
