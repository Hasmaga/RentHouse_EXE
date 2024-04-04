using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IPostRepository 
    {
        Task<Guid> CreatePostAsync(PostRealEstate post);
        Task<PostRealEstate?> GetPostByIdAsync(Guid id);
        Task<List<PostRealEstate>> GetAllPostsAsync();
        Task<List<PostRealEstate>> GetListPostsByCustomerPostId(Guid customerPostId);
    }
}
