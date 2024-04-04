using RentHouse_EXE.Model;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{

    public class ImageRealEstateService : IImageRealEstateService
    {
        private readonly IImageRealEstateRepository _imageRealEstateRepository;
        private readonly IHelperService _helperService;
        private readonly IStatusRepository _statusRepository;
        private readonly IPostRepository _postRepository;

        public ImageRealEstateService(IImageRealEstateRepository imageRealEstateRepository, IHelperService helperService, IStatusRepository statusRepository = null, IPostRepository postRepository = null)
        {
            _imageRealEstateRepository = imageRealEstateRepository;
            _helperService = helperService;
            _statusRepository = statusRepository;
            _postRepository = postRepository;
        }

        public async Task<bool> UploadImageRealEstateAsync(List<IFormFile> files, Guid postId)
        {
            try
            {
                // Check if files is null
                if (files == null || files.Count == 0)
                {
                    throw new Exception("File is empty");
                }

                var statusActive = await _statusRepository.GetStatusByNameRepository("ACTIVE") ?? throw new Exception("Status not found");
                var postExist = await _postRepository.GetPostByIdAsync(postId) ?? throw new Exception("Post not found");
                
                // Convert List IFormFile to byte array and upload to database
                foreach (var file in files)
                {
                    var imageRealEstate = new ImageRealEstate
                    {
                        Image = _helperService.ConvertIFormFileToByteArray(file),
                        PostRealEstateId = postId,
                        StatusId = statusActive.Id
                    };
                    await _imageRealEstateRepository.UploadImageRealEstateAsync(imageRealEstate);
                }
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
