using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RentHouseDbContext _db;

        public AccountRepository(RentHouseDbContext db)
        {
            _db = db;
        }

        // Create Account
        public async Task<bool> CreateAccountRepository(Account account)
        {
            try
            {
                await _db.Accounts.AddAsync(account);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        // Get All Account
        public async Task<List<Account>?> GetAllAccountRepository()
        {
            try
            {
                return await _db.Accounts.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        // Get Account By Id
        public async Task<Account?> GetAccountByIdRepository(Guid id)
        {
            try
            {
                return await _db.Accounts.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        // Update Account
        public async Task<bool> UpdateAccountRepository(Account account)
        {
            try
            {
                _db.Accounts.Update(account);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Account?> GetAccountByEmailRepository(string email)
        {
            try
            {                
                return await _db.Accounts.FirstOrDefaultAsync(x => x.Email == email);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
