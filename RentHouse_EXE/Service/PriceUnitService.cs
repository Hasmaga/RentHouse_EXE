using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto.PriceUnit;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class PriceUnitService : IPriceUnitService
    {
        private readonly IPriceUnitRepository _priceUnitRepository;

        public PriceUnitService(IPriceUnitRepository priceUnitRepository)
        {
            _priceUnitRepository = priceUnitRepository;
        }

        public async Task<bool> CreatePriceUnitAsync(CreatePriceUnitReqDto priceUnit)
        {
            try
            {
                PriceUnit newPriceUnit = new()
                {
                    Name = priceUnit.Name
                };

                return await _priceUnitRepository.CreatePriceUnitAsync(newPriceUnit);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PriceUnitResDto>> GetAllPriceUnitsAsync()
        {
            try
            {
                var priceUnits = await _priceUnitRepository.GetAllPriceUnitsAsync();
                return priceUnits.Select(p => new PriceUnitResDto
                {
                    PriceUnitId = p.Id,
                    Name = p.Name
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
