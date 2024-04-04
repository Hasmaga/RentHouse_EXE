using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IPaymentHistoryRepository
    {
        Task<bool> CreatePaymentHistoryAsync(PaymentHistory paymentHistory);
        Task<PaymentHistory?> GetPaymentHistoryByCodeAsync(string code);
        Task<bool> UpdatePaymentHistoryAsync(PaymentHistory paymentHistory);
        
    }
}
