using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IFurnitureRepository
    {
        Task<bool> CreateFurnitureAsync(Furniture furniture);
        Task<List<Furniture>> GetAllListFurnitureAsync();
        Task<Furniture?> GetFurnitureByIdAsync(Guid id);
    }
}
