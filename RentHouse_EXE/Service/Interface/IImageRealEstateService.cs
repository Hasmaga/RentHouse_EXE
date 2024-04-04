namespace RentHouse_EXE.Service.Interface
{
    public interface IImageRealEstateService
    {
        Task<bool> UploadImageRealEstateAsync(List<IFormFile> files, Guid postId);
    }
}
