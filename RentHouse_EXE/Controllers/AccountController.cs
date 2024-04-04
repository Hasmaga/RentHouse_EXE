using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Enum;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Account;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [Route("accountapi")]
    [ApiController]
    public class AccountController(IAccountService accountRepository) : Controller
    {
        private readonly IAccountService _accountService = accountRepository;

        // POST: accountapi/createaccount
        [HttpPost("createaccount")]
        public async Task<IActionResult> CreateAccountCustomer([FromBody] CreateAccount CusAcc)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Invalid data!");
                }
                var result = await _accountService.CreateAccountCustomerService(CusAcc);
                if (result)
                {
                    return StatusCode(200, "Create account successfully!");
                }
                return StatusCode(500, "Create account failed!");
            } catch (Exception e)
            {
                if (e.Message.Equals(AccountErrorEnum.CREATE_ACCOUNT_FAILED))
                {
                    return StatusCode(500, "Create account failed!");
                } else if (e.Message.Equals(AccountErrorEnum.ACCOUNT_IS_EXIST))
                {
                    return StatusCode(400, "Account is exist!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // GET: accountapi/getaccountbyid/{id}
        [Authorize]
        [HttpGet("getaccountbyid/{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            try
            {
                var result = await _accountService.GetAccountByIdService(id);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(404, AccountErrorEnum.ACCOUNT_NOT_FOUND);
            } catch (Exception)
            {
                return StatusCode(500, ServerErrorEnum.SERVER_ERROR);
            }
        }

        // GET: accountapi/getallaccount
        [Authorize]
        [HttpGet("getallaccount")]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                var result = await _accountService.GetAllAccountService();
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(404, "Account not found!");
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        // PUT: accountapi/updateaccount
        [Authorize]
        [HttpPut("updateprofile")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateProfileAccount account)
        {
            try
            {
                var result = await _accountService.UpdateProfileAccService(account);
                if (result)
                {
                    return StatusCode(200, "Update account successfully!");
                }
                return StatusCode(500, "Update account failed!");
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginAccount acc)
        {
            try
            {
                var result = await _accountService.LoginService(acc);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(400, "Email or Password not correct");
            } catch(Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpGet("getaccount")]
        public async Task<IActionResult> GetAccount()
        {
            try
            {
                var result = await _accountService.GetAccountAsync();
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(404, "Account not found!");
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordReqDto changePasswordReqDto)
        {
            try
            {
                var result = await _accountService.ChangePasswordUserAsync(changePasswordReqDto);
                if (result)
                {
                    return StatusCode(200, "Change password successfully!");
                }
                return StatusCode(500, "Change password failed!");
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
