using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;

namespace RentHouse_EXE.Service.Interface
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CreateCommentReqDto commentRealEstate);
        Task<List<GetCommentResDto>> GetListCommentByPostIdAsync(Guid postId);
        Task<bool> DeleteCommentAsync(Guid commentId);
    }
}
