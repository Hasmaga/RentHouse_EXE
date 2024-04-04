using Newtonsoft.Json;
using RentHouse_EXE.Model;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace RentHouse_EXE.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountRepository _accountRepository;     
        private readonly IHelperService _helperService;
        private readonly IPaymentHistoryRepository _paymentHistoryRepository;
        private readonly IStatusRepository _statusRepository;

        public PaymentService(IAccountRepository accountRepository, IHelperService helperService, IPaymentHistoryRepository paymentHistoryRepository, IStatusRepository statusRepository)
        {
            _accountRepository = accountRepository;
            _helperService = helperService;
            _paymentHistoryRepository = paymentHistoryRepository;
            _statusRepository = statusRepository;
        }

        public async Task<bool> CallbackZaloPay(string app_trans_id)
        {
            try
            {
                var paymentHistory = await _paymentHistoryRepository.GetPaymentHistoryByCodeAsync(app_trans_id);
                if (paymentHistory == null)
                {
                    throw new Exception("Payment history not found");
                }
                var status = await _statusRepository.GetStatusByNameRepository("CONFIRMED");
                paymentHistory.StatusId = status.Id;
                await _paymentHistoryRepository.UpdatePaymentHistoryAsync(paymentHistory);
                var account = await _accountRepository.GetAccountByIdRepository(paymentHistory.AccountId) ?? throw new Exception("Account not found");
                account.Wallet += paymentHistory.Amount;
                await _accountRepository.UpdateAccountRepository(account);                
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> CreateZaloPayRequest(decimal amount)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Token is invalid");
                }
                var customer = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged());
                if (customer == null)
                {
                    throw new Exception("Customer not found");
                }
                string app_id = "2553";
                string key1 = "PcY4iZIKFCIdgZvA6ueMcMHHUbRLYjPL";
                string create_order_url = "https://sb-openapi.zalopay.vn/v2/create";

                Random rnd = new Random();
                var embed_data = new {
                    redirecturl = "https://localhost:7149/callback",
                    accountId = customer.Id.ToString() 
                };
                var items = new[] { new { } };
                var param = new Dictionary<string, string>();
                var app_trans = rnd.Next(1000000); // Generate a random order's ID.
                var app_trans_id = DateTime.Now.ToString("yyMMdd") + "_" + app_trans;
                param.Add("app_id", app_id);
                param.Add("app_user", "user123");
                param.Add("app_time", Utils.GetTimeStamp().ToString());
                param.Add("amount", amount.ToString());
                param.Add("app_trans_id", app_trans_id);
                param.Add("embed_data", JsonConvert.SerializeObject(embed_data));
                param.Add("item", JsonConvert.SerializeObject(items));
                param.Add("description", "RentHouse - Thanh toán đơn hàng #" + app_trans_id);
                param.Add("bank_code", "zalopayapp");
                param.Add("email", "khangbpak2001@gmail.com");


                var data = app_id + "|" + param["app_trans_id"] + "|" + param["app_user"] + "|" + param["amount"] + "|"
                    + param["app_time"] + "|" + param["embed_data"] + "|" + param["item"];
                param.Add("mac", HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key1, data));

                var response = await HttpHelper.PostFormAsync(create_order_url, param);
                // convert response to object

                string result = JsonConvert.SerializeObject(response);
                await _paymentHistoryRepository.CreatePaymentHistoryAsync(new PaymentHistory
                {
                    AccountId = customer.Id,
                    Amount = amount,
                    Code = app_trans_id,
                    StatusId = (await _statusRepository.GetStatusByNameRepository("PENDING")).Id
                });
                return result;
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
