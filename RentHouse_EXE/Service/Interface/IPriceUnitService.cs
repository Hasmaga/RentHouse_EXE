using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto.PriceUnit;

namespace RentHouse_EXE.Service.Interface
{
    public interface IPriceUnitService
    {
        Task<bool> CreatePriceUnitAsync(CreatePriceUnitReqDto priceUnit);
        Task<List<PriceUnitResDto>> GetAllPriceUnitsAsync();
    }
}
