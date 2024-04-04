using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface ICommentRealEstateRepository
    {
        Task<bool> CreateCommentAsync(CommentRealEstate commentRealEstate);
        Task<List<CommentRealEstate>> GetListCommentByPostIdAsync(Guid postId);
        Task<bool> DeleteCommentAsync(CommentRealEstate comment);
        Task<CommentRealEstate?> GetCommentByIdAsync(Guid commentId);
    }
}
