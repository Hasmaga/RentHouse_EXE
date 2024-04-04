using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto.Plan;
using RentHouse_EXE.Model.ResDto.Plan;

namespace RentHouse_EXE.Service.Interface
{
    public interface IPlanService
    {
        Task<bool> CreatePlanAsync(CreatePlanResDto plan);        
        Task<bool> CreatePlanDayAsync(CreatePlanDayReqDto priceDay);
        Task<bool> CreatePriceDecreasesAsync(CreatePriceDescreaseReqDto priceDecreases);
        Task<bool> CreatePlanPriceAsync(CreatePlanPriceReqDto planPrice);
        Task<List<Plan>> GetListPlanAsync();
        Task<List<PlanDay>> GetListPlanDayAsync();
        Task<List<PlanPrice>> GetListPlanPriceAsync();
        Task<List<PriceDecreases>> GetListPriceDecreasesAsync();
        Task<List<PlanPriceResDto>> GetListPlanPriceResDtoAsync();
        Task<List<PlanPriceOfDayResDto>> GetListPlanPriceOfDayAysnc(Guid planId);
    }
}
