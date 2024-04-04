using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;

namespace RentHouse_EXE.Service.Interface
{
    public interface ITypeRealEstateService
    {
        Task<bool> CreateTypeRealEstateAsync(CreateTypeRealEstateResDto typeRealEstate);
        Task<List<GetTypeRealEstateResDto>> GetListTypeRealEstateAsync();
    }
}
