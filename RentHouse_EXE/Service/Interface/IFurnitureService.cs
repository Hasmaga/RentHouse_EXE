using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;

namespace RentHouse_EXE.Service.Interface
{
    public interface IFurnitureService
    {
        Task<bool> CreateFurnitureAsync(CreateFurnitureReqDto createFurnitureReqDto);
        Task<List<FurnitureResDto>> GetAllListFurnitureAsync();
    }
}
