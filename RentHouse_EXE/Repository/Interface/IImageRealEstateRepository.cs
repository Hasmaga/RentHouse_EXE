using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IImageRealEstateRepository
    {
        Task<bool> UploadImageRealEstateAsync(ImageRealEstate imageRealEstate);
        Task<byte[]?> GetTheFirstImageRealEstateAsync(Guid realEstateId);
        Task<List<byte[]>?> GetAllImageRealEstateAsync(Guid realEstateId);
    }
}
