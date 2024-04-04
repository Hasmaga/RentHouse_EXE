using RentHouse_EXE.Model.ReqDto;

namespace RentHouse_EXE.Service.Interface
{
    public interface IReplyCommentService
    {
        Task<bool> CreateReplyCommentAsync(CreateReplyCommentReqDto replyComment);
        Task<bool> CreateChildReplyCommentAsync(CreateReplyCommentReqDto replyComment);
    }
}
