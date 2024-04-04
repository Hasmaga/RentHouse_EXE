using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface ILikeCommentRepository
    {
        Task<bool> CreateLikeCommentAsync(LikeComment likeComment);
        Task<bool> DeleteLikeCommentAsync(LikeComment likeComment);
        Task<List<LikeComment>> GetListLikeByCommentIdAsync(Guid commentId);
        Task<List<LikeComment>> GetListLikeByReplyCommentId(Guid replyCommentId);
        Task<LikeComment?>GetLikeCommentByIdAsync(Guid likeCommentId);
    }
}
