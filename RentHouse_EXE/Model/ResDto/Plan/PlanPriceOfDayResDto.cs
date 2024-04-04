namespace RentHouse_EXE.Model.ResDto.Plan
{
    public class PlanPriceOfDayResDto
    {
        public Guid PlanDayId { get; set; }
        public int Day { get; set; }
        public decimal PriceNonDiscount { get; set; }
        public decimal PriceDiscount { get; set; }
    }
}
