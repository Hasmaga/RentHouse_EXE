namespace RentHouse_EXE.Model.ResDto.Plan
{
    public class PlanPriceResDto
    {
        public Guid PlanId { get; set; }
        public string PlanName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
