using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ResDto.Plan;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private readonly RentHouseDbContext _context;

        public PlanRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePlanAsync(Plan plan)
        {
            try
            {
                await _context.Plans.AddAsync(plan);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Plan>> GetListPlanAsync()
        {
            try
            {
                return await _context.Plans.ToListAsync();
            } catch (Exception) 
            {
                throw;
            }            
        }

        public async Task<bool> CreatePlanDayAsync(PlanDay priceDay)
        {
            try
            {
                await _context.PlanDays.AddAsync(priceDay);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreatePriceDecreasesAsync(PriceDecreases priceDecreases)
        {
            try
            {
                await _context.PriceDecreases.AddAsync(priceDecreases);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreatePlanPriceAsync(PlanPrice pricePlan)
        {
            try
            {
                await _context.PricePlans.AddAsync(pricePlan);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PlanDay>> GetListPlanDayAsync()
        {
            try
            {
                return await _context.PlanDays.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PriceDecreases>> GetListPriceDecreasesAsync()
        {
            try
            {
                return await _context.PriceDecreases.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PlanPrice>> GetListPlanPriceAsync()
        {
            try
            {
                return await _context.PricePlans.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Plan?> GetPlanByIdAsync(Guid id)
        {
            try
            {
                return await _context.Plans.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<PlanPrice?> GetPlanPriceByPlanIdAsync(Guid planId)
        {
            try
            {
                return await _context.PricePlans.FirstOrDefaultAsync(x => x.PlanId == planId);
            } catch (Exception)
            {
                throw;
            }
        }   

        public async Task<PlanDay?> GetPlanDayByIdAsync(Guid id)
        {
            try
            {
                return await _context.PlanDays.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PriceDecreases?> GetPriceDecreasesByPlanDayIdAsync(Guid PlanDayId)
        {
            try
            {
                return await _context.PriceDecreases.FirstOrDefaultAsync(x => x.PlanDayId == PlanDayId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PlanPrice?> GetPlanPriceByPlanNameAsync(string name)
        {
            try
            {
                var query = from plan in _context.Plans
                            join price in _context.PricePlans on plan.Id equals price.PlanId
                            where plan.Name == name
                            select price;
                return await query.FirstOrDefaultAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Plan?> GetPlanByPlanPriceIdAsync(Guid id)
        {
            try
            {
                var query = from plan in _context.Plans
                            join price in _context.PricePlans on plan.Id equals price.PlanId
                            where price.Id == id
                            select plan;
                return await query.FirstOrDefaultAsync();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
