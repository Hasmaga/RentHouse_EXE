using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccountRepository(Account account);
        Task<List<Account>?> GetAllAccountRepository();
        Task<Account?> GetAccountByIdRepository(Guid id);
        Task<bool> UpdateAccountRepository(Account account);
        Task<Account?> GetAccountByEmailRepository(string email);
    }
}
