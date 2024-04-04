namespace RentHouse_EXE.Service.Interface
{
    public interface IPaymentService
    {
        Task<string> CreateZaloPayRequest(decimal amount);
        Task<bool> CallbackZaloPay(string app_trans_id);
    }
}
