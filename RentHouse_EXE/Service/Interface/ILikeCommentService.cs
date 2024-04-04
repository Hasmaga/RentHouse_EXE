namespace RentHouse_EXE.Service.Interface
{
    public interface ILikeCommentService
    {
        Task<bool> LikeCommentAsync(Guid commentId);
        Task<bool> UnlikeCommennAsync(Guid commentId);
    }
}
