using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto.Plan;
using RentHouse_EXE.Model.ResDto.Plan;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IHelperService _helperService;

        public PlanService(IPlanRepository planRepository, IHelperService helperService)
        {
            _planRepository = planRepository;
            _helperService = helperService;
        }

        public async Task<bool> CreatePlanAsync(CreatePlanResDto plan)
        {
            try
            {
                Plan newPlan = new()
                {
                    Name = plan.Name
                };
                return await _planRepository.CreatePlanAsync(newPlan);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreatePlanPriceAsync(CreatePlanPriceReqDto planPrice)
        {
            try
            {
                PlanPrice newPlanPrice = new()
                {
                    PlanId = planPrice.PlanId,
                    Price = planPrice.Price
                };
                return await _planRepository.CreatePlanPriceAsync(newPlanPrice);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreatePlanDayAsync(CreatePlanDayReqDto planDay)
        {
            try
            {
                PlanDay newPlanDay = new()
                {
                    Day = planDay.Day
                };
                return await _planRepository.CreatePlanDayAsync(newPlanDay);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreatePriceDecreasesAsync(CreatePriceDescreaseReqDto priceDecreases)
        {
            try
            {
                PriceDecreases newPriceDecreases = new()
                {
                    PlanDayId = priceDecreases.PriceDayId,
                    PercentageDecrease = priceDecreases.PercentageDescrease                    
                };
                return await _planRepository.CreatePriceDecreasesAsync(newPriceDecreases);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Plan>> GetListPlanAsync()
        {
            try
            {
                return await _planRepository.GetListPlanAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PlanDay>> GetListPlanDayAsync()
        {
            try
            {
                return await _planRepository.GetListPlanDayAsync();
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<PlanPrice>> GetListPlanPriceAsync()
        {
            try
            {
                return await _planRepository.GetListPlanPriceAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PriceDecreases>> GetListPriceDecreasesAsync()
        {
            try
            {
                return await _planRepository.GetListPriceDecreasesAsync();
            } catch (Exception )
            {
                throw;
            }
        }

        public async Task<List<PlanPriceResDto>> GetListPlanPriceResDtoAsync()
        {
            try
            {
                // Get List<PlanPriceResDto> 
                var list = await _planRepository.GetListPlanPriceAsync();        
                List<PlanPriceResDto> listPlanPriceResDto = [];
                foreach (var item in list)
                {
                    Plan plan = await _planRepository.GetPlanByIdAsync(item.PlanId) ?? new Plan();
                    PlanPriceResDto planPriceResDto = new()
                    {
                        PlanId = item.PlanId,
                        Price = item.Price,
                        PlanName = plan.Name
                    };
                    listPlanPriceResDto.Add(planPriceResDto);
                }
                return listPlanPriceResDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<PlanPriceOfDayResDto>> GetListPlanPriceOfDayAysnc(Guid planId)
        {
            try
            {
                var planPrice = await _planRepository.GetPlanPriceByPlanIdAsync(planId) ?? throw new Exception("Plan Price not found");
                var listPriceDecreases = await _planRepository.GetListPriceDecreasesAsync();
                var listPlanDay = await _planRepository.GetListPlanDayAsync();
                List<PlanPriceOfDayResDto> listPlanPriceOfDayResDto = [];
                foreach (var item in listPlanDay)
                {
                    var priceDecrease = listPriceDecreases.FirstOrDefault(x => x.PlanDayId == item.Id);
                    PlanPriceOfDayResDto planPriceOfDayResDto = new()
                    {
                        PlanDayId = item.Id,
                        Day = item.Day,
                        PriceNonDiscount = planPrice.Price * item.Day,
                        PriceDiscount = planPrice.Price * item.Day * (1 - priceDecrease.PercentageDecrease / 100)
                    };                    
                    listPlanPriceOfDayResDto.Add(planPriceOfDayResDto);
                }
                return listPlanPriceOfDayResDto;               
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
