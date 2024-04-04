using RentHouse_EXE.Model.Provinces;

namespace RentHouse_EXE.Repository.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Provinces>> GetAllCityRepository();
        Task<IEnumerable<Districts>> GetAllDistrictByCityIdRepository(int cityId);
        Task<IEnumerable<Wards>> GetAllWardByDistrictIdRepository(int districtId);
        Task<Provinces?> GetCityByIdAsync(string cityId);
        Task<Districts?> GetDistrictByIdAsync(string districtId);
        Task<Wards?> GetWardByIdAsync(string wardId);
    }
}
