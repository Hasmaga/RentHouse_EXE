using RentHouse_EXE.Model;
using System.ComponentModel;

namespace RentHouse_EXE.Repository.Interface
{
    public interface ITypeRealEstateRepository
    {
        Task<bool> CreateTypeRealEstateAsync(TypeRealEstate typeRealEstate);
        Task<TypeRealEstate?> GetTypeRealEstateByNameAsync(string Name);
        Task<TypeRealEstate?> GetTypeRealEstateByIdAsync(Guid id);
        Task<List<TypeRealEstate>> GetListTypeRealEstateAsync();
    }
}
