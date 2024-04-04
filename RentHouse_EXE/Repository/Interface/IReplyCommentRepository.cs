using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IReplyCommentRepository
    {
        Task<bool> CreateReplyCommentAsync(ReplyComment replyComment);
        Task<List<ReplyComment>> GetListReplyCommentByCommentIdAsync(Guid commentId);
        Task<List<ReplyComment>> GetListReplyCommentByParentReplyCommentIdAsync(Guid parentReplyCommentId);
        Task<bool> DeleteReplyCommentAsync(ReplyComment replyComment);
    }
}
