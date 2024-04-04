using Microsoft.IdentityModel.Tokens;
using RentHouse_EXE.Enum;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Account;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RentHouse_EXE.Service
{
    public class AccountService(IAccountRepository accountRepository, IRoleRepository roleRepository, IConfiguration configuration, IStatusRepository statusRepository, IHelperService helperService) : IAccountService
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IConfiguration _configuration = configuration;        
        private readonly IStatusRepository _statusRepository = statusRepository;
        private readonly IHelperService _helperService = helperService;
        

        // Create Account Customer (Role = Customer)
        public async Task<bool> CreateAccountCustomerService(CreateAccount cusAcc)
        {
            try
            {
                // Get RoleId Customer
                var roleId = await _roleRepository.GetRoleByNameRepository("CUSTOMER");
                return roleId == null ? throw new Exception(AccountErrorEnum.CREATE_ACCOUNT_FAILED) : await CreateAccountService(cusAcc, roleId.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get Account By Id (Only Admin)
        public async Task<Account?> GetAccountByIdService(Guid id)
        {
            try
            {
                // Check bearer token is valid and not expired
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var acc = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                var role = await _roleRepository.GetRoleByIdRepository(acc.RoleId);
                if (role == null || !role.RoleName.Equals("ADMIN"))
                {
                    throw new Exception(AuthEnum.NOT_AUTHORIZED);
                }
                return await _accountRepository.GetAccountByIdRepository(id);
            } catch (Exception)
            {
                throw;
            }
        }

        // Get All Account (Only Admin)
        public async Task<List<GetAllAccount>?> GetAllAccountService()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var acc = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                var role = await _roleRepository.GetRoleByIdRepository(acc.RoleId);
                if (role == null || !role.RoleName.Equals("ADMIN"))
                {
                    throw new Exception(AuthEnum.NOT_AUTHORIZED);
                }
                var listAcc = await _accountRepository.GetAllAccountRepository();
                if (listAcc == null || listAcc.Count == 0)
                {
                    throw new Exception(AccountErrorEnum.ACCOUNT_NOT_FOUND);
                }
                List<GetAllAccount> listAccDto = [];
                foreach (var item in listAcc)
                {
                    var roleAcc = (await _roleRepository.GetRoleByIdRepository(item.RoleId))!.RoleName ?? "NULL";
                    var statusAcc = (await _statusRepository.GetStatusByIdRepository(item.StatusId))!.StatusName ?? "NULL";
                    listAccDto.Add(new GetAllAccount
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber,
                        Role = roleAcc,
                        Status = statusAcc
                    });
                }
                return listAccDto;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetAccountResDto> GetAccountAsync()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var acc = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                return new GetAccountResDto
                {
                    FirstName = acc.FirstName,
                    LastName = acc.LastName,
                    Email = acc.Email,
                    PhoneNumber = acc.PhoneNumber,
                    Wallet = acc.Wallet
                };
            } catch (Exception)
            {
                throw;
            }
        }

        // Update Profile By Account Logined (All Role)
        public async Task<bool>UpdateProfileAccService(UpdateProfileAccount acc)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var upAcc = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                UpdateAccount update = new()
                {
                    FirstName = acc.FristName,
                    LastName = acc.LastName,
                    PhoneNumber = acc.PhoneNumber                    
                }; 
                return await UpdateAccountMainService(update, upAcc.Id);
            } catch (Exception)
            {
                throw;
            }
        }

        // Login Account
        public async Task<string> LoginService(LoginAccount loginAcc)
        {
            try
            {
                var account = await _accountRepository.GetAccountByEmailRepository(loginAcc.Email);
                if (account == null)
                {
                    throw new Exception(AccountErrorEnum.ACCOUNT_NOT_FOUND);
                }
                else
                {
                    if (VerifyPasswordHash(loginAcc.Password, Convert.FromBase64String(account.PasswordSalt), account.PasswordHash))
                    {
                        return CreateBearerTokenAccount(account);
                    }
                    else
                    {
                        throw new Exception(AccountErrorEnum.LOGIN_FAILED);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> DepositToAccountAsync(Guid accountId, decimal money)
        {
            try
            {
                var account = await _accountRepository.GetAccountByIdRepository(accountId);
                if (account == null)
                {
                    throw new Exception(AccountErrorEnum.ACCOUNT_NOT_FOUND);
                }
                account.Wallet += money;
                return await _accountRepository.UpdateAccountRepository(account);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ChangePasswordUserAsync(ChangePasswordReqDto changePasswordReqDto)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                // Get Account
                var account = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                if (!VerifyPasswordHash(changePasswordReqDto.OldPassword, Convert.FromBase64String(account.PasswordSalt), account.PasswordHash))
                {
                    throw new Exception("OLD_PASSWORD_INCORRECT");
                }
                var passwordHash = CreatePassHashAndPassSalt(changePasswordReqDto.NewPassword, out byte[] passwordSalt);
                if (passwordHash == null || passwordSalt == null)
                {
                    throw new Exception("SERVER_ERROR");
                }
                account.PasswordHash = passwordHash;
                account.PasswordSalt = Convert.ToBase64String(passwordSalt);
                return await _accountRepository.UpdateAccountRepository(account);
            } catch (Exception)
            {
                throw;
            }
        }

        #region Private Method

        // Update Account Main
        private async Task<bool> UpdateAccountMainService(UpdateAccount acc, Guid accId)
        {
            try
            {
                // Check is account exist
                var accUpdate = await _accountRepository.GetAccountByIdRepository(accId);
                if (accUpdate == null)
                {
                    throw new Exception(AccountErrorEnum.ACCOUNT_NOT_FOUND);
                }
                else
                {
                    // Check UpdateAccount model if null then not update else update
                    if (acc.FirstName != null)
                    {
                        accUpdate.FirstName = acc.FirstName.TrimEnd().TrimStart();
                    }
                    if (acc.LastName != null)
                    {
                        accUpdate.LastName = acc.LastName.TrimEnd().TrimStart();
                    }
                    if (acc.Password != null)
                    {
                        var passwordHash = CreatePassHashAndPassSalt(acc.Password, out byte[] passwordSalt);
                        if (passwordHash == null || passwordSalt == null)
                        {
                            throw new Exception(AccountErrorEnum.UPDATE_ACCOUNT_FAILED);
                        }
                        accUpdate.PasswordHash = passwordHash;
                        accUpdate.PasswordSalt = Convert.ToBase64String(passwordSalt);
                    }
                    if (acc.PhoneNumber != null)
                    {
                        accUpdate.PhoneNumber = acc.PhoneNumber;
                    }
                    if (acc.StatusId != null)
                    {
                        accUpdate.StatusId = (Guid)acc.StatusId;
                    }
                    if (acc.RoleId != null)
                    {
                        accUpdate.RoleId = (Guid)acc.RoleId;
                    }
                    accUpdate.UpdateDateTime = DateTime.Now;
                    return await _accountRepository.UpdateAccountRepository(accUpdate);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Create Account Main
        private async Task<bool> CreateAccountService(CreateAccount account, Guid roleId)
        {
            try
            {
                // Check is account exist
                var isExist = await _accountRepository.GetAccountByEmailRepository(account.Email);
                if (isExist != null)
                {
                    throw new Exception(AccountErrorEnum.ACCOUNT_IS_EXIST);
                }
                else
                {
                    var passwordHash = CreatePassHashAndPassSalt(account.Password, out byte[] passwordSalt);
                    if (passwordHash == null || passwordSalt == null)
                    {
                        throw new Exception(AccountErrorEnum.CREATE_ACCOUNT_FAILED);
                    }
                    Account newAccount = new()
                    {
                        FirstName = account.FirstName.TrimEnd().TrimStart(),
                        LastName = account.LastName.TrimEnd().TrimStart(),
                        Email = account.Email.TrimEnd().TrimStart().ToLower(),
                        PasswordHash = passwordHash,
                        PasswordSalt = Convert.ToBase64String(passwordSalt),
                        PhoneNumber = account.PhoneNumber,
                        StatusId = (await _statusRepository.GetStatusByNameRepository("ACTIVE"))!.Id,
                        RoleId = roleId,
                        CreateDateTime = DateTime.Now
                    };
                    if (await _accountRepository.CreateAccountRepository(newAccount))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(AccountErrorEnum.CREATE_ACCOUNT_FAILED);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Create Password Hash and Password Salt
        private static string CreatePassHashAndPassSalt(string pass, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            return System.Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass)));
        }

        // Verify Password Hash
        private static bool VerifyPasswordHash(string pass, byte[] passwordSalt, string passwordHash)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass)));
            return computedHash.Equals(passwordHash);
        }

        // Create Bearer Token
        private string CreateBearerTokenAccount(Account loginedAcc)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.Sid, loginedAcc.Id.ToString()),
            ];            
            var securityKey = _configuration.GetSection("AppSettings:Token").Value ?? throw new Exception(ServerErrorEnum.SERVER_ERROR);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token == null ? throw new Exception(ServerErrorEnum.SERVER_ERROR) : tokenHandler.WriteToken(token);
        }        
        #endregion
    }
}
