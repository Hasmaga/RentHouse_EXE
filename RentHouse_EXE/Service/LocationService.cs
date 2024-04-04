using RentHouse_EXE.Model.Provinces;
using RentHouse_EXE.Model.ResDto.Districts;
using RentHouse_EXE.Model.ResDto.Provinces;
using RentHouse_EXE.Model.ResDto.Wards;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class LocationService(ILocationRepository cityRepository) : ILocationService
    {
        private readonly ILocationRepository _cityRepository = cityRepository;

        public async Task<List<ProvincesResDto>> GetAllCityService()
        {
            try
            {
                var result = (await _cityRepository.GetAllCityRepository()).ToList();                
                var listCity = new List<ProvincesResDto>();
                // id follow index of list
                for (int i = 0; i < result.Count; i++)
                {
                    var city = new ProvincesResDto
                    {
                        Id = Convert.ToInt32(result[i].Code),
                        Full_name = result[i].Full_name
                    };
                    listCity.Add(city);
                }
                return listCity;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DistrictsResDto>> GetAllDistrictByCityIdService(int cityId)
        {
            try
            {
                var result = (await _cityRepository.GetAllDistrictByCityIdRepository(cityId)).ToList();
                var listDistrict = new List<DistrictsResDto>();
                // id follow index of list
                for (int i = 0; i < result.Count; i++)
                {
                    var district = new DistrictsResDto
                    {
                        Id = Convert.ToInt32(result[i].Code),
                        Full_name = result[i].Full_name ?? ""
                    };
                    listDistrict.Add(district);
                }
                return listDistrict;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<WardsResDto>> GetAllWardByDistrictIdService(int districtId)
        {
            try
            {
                var result = (await _cityRepository.GetAllWardByDistrictIdRepository(districtId)).ToList();
                var listWard = new List<WardsResDto>();
                for (int i = 0; i < result.Count; i++)
                {
                    var ward = new WardsResDto
                    {
                        Id = Convert.ToInt32(result[i].Code),
                        Full_name = result[i].Full_name ?? ""
                    };
                    listWard.Add(ward);
                }
                return listWard;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
