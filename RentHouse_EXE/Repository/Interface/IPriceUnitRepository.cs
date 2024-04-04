using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IPriceUnitRepository
    {
        Task<bool> CreatePriceUnitAsync(PriceUnit priceUnit);
        Task<List<PriceUnit>> GetAllPriceUnitsAsync();
        Task<PriceUnit?> GetPriceUnitByIdAsync(Guid id);
    }
}
