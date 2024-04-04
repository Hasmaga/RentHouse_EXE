using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IPlanRepository
    {
        Task<bool> CreatePlanAsync(Plan plan);        
        Task<bool> CreatePlanDayAsync(PlanDay priceDay);
        Task<bool> CreatePriceDecreasesAsync(PriceDecreases priceDecreases);
        Task<bool> CreatePlanPriceAsync(PlanPrice pricePlan);
        Task<List<Plan>> GetListPlanAsync();
        Task<List<PlanDay>> GetListPlanDayAsync();
        Task<List<PriceDecreases>> GetListPriceDecreasesAsync();
        Task<List<PlanPrice>> GetListPlanPriceAsync();
        Task<Plan?> GetPlanByIdAsync(Guid id);
        Task<PlanPrice?> GetPlanPriceByPlanIdAsync(Guid planId);
        Task<PlanDay?> GetPlanDayByIdAsync(Guid id);
        Task<PriceDecreases?> GetPriceDecreasesByPlanDayIdAsync(Guid PlanDayId);        
        Task<PlanPrice?> GetPlanPriceByPlanNameAsync(string name);
        Task<Plan?> GetPlanByPlanPriceIdAsync(Guid id);
    }
}
