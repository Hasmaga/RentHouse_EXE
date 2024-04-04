using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Account;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;

namespace RentHouse_EXE.Service.Interface
{
    public interface IAccountService
    {
        Task<bool> CreateAccountCustomerService(CreateAccount CusAcc);
        Task<List<GetAllAccount>?> GetAllAccountService();
        Task<Account?> GetAccountByIdService(Guid id);
        Task<bool> UpdateProfileAccService(UpdateProfileAccount account);
        Task<string> LoginService(LoginAccount loginAcc);
        Task<GetAccountResDto> GetAccountAsync();
        Task<bool> DepositToAccountAsync(Guid accountId, decimal money);
        Task<bool> ChangePasswordUserAsync(ChangePasswordReqDto changePasswordReqDto);
    }
}
