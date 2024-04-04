using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;

namespace RentHouse_EXE.Repository.Interface
{
    public class PaymentHistoryRepository : IPaymentHistoryRepository
    {
        private readonly RentHouseDbContext _context;

        public PaymentHistoryRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePaymentHistoryAsync(PaymentHistory paymentHistory)
        {
            try
            {
                await _context.PaymentHistories.AddAsync(paymentHistory);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaymentHistory?> GetPaymentHistoryByCodeAsync(string code)
        {
            try
            {
                return await _context.PaymentHistories.FirstOrDefaultAsync(x => x.Code == code);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePaymentHistoryAsync(PaymentHistory paymentHistory)
        {
            try
            {
                _context.PaymentHistories.Update(paymentHistory);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
