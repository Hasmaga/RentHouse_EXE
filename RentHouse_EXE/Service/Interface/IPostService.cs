using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;

namespace RentHouse_EXE.Service.Interface
{
    public interface IPostService
    {
        Task<Guid> CreatePostRealEstateAsync(CreatePostRealEstateReqDto post);
        Task<List<GetTitlePostRealEstateResDto>> GetTitleRentPostRealEstateAsync();
        Task<List<GetTitlePostRealEstateResDto>> GetTitleBuyPostRealEstateAsync();
        Task<GetPostRealEstateResDto> GetPostRealEstateByIdAsync(Guid id);
        Task<List<GetTitlePostRealEstateResDto>> GetTitleRentPostRealEstateByPlanTopAsync();
        Task<List<GetTitlePostRealEstateResDto>> GetTitleBuyPostRealEstateByPlanTopAsync();
        Task<List<GetTitlePostRealEstateResDto>> GetTitlePostRealEstateByCustomerIdAsync();        
        Task<GetCustomerPostRealStateResDto> GetCustomerPostRealEstateByIdAsync(Guid id);        
    }
}
