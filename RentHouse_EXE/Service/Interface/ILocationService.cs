using RentHouse_EXE.Model.Provinces;
using RentHouse_EXE.Model.ResDto.Districts;
using RentHouse_EXE.Model.ResDto.Provinces;
using RentHouse_EXE.Model.ResDto.Wards;

namespace RentHouse_EXE.Service.Interface
{
    public interface ILocationService
    {
        Task<List<ProvincesResDto>> GetAllCityService();
        Task<List<DistrictsResDto>> GetAllDistrictByCityIdService(int cityId);
        Task<List<WardsResDto>> GetAllWardByDistrictIdService(int districtId);
    }
}
