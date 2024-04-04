using System.ComponentModel;

namespace RentHouse_EXE.Model.ResDto
{
    public class GetCustomerPostRealStateResDto
    {
        public string? Name { get; set; }
        public string? TypeRealEstate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Street { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? Phone { get; set; }
        public decimal Price { get; set; }
        public string? PriceUnit { get; set; }
        public string? Furniture { get; set; }
        public int TotalRoom { get; set; }
        public int TotalBathroom { get; set; }
        public int TotalBedroom { get; set; }
        public int TotalFloor { get; set; }
        public decimal Area { get; set; }
        public string? Plan { get; set; }
        public int PlanDay { get; set; }
        public DateOnly PostDate { get; set; }
        public TimeOnly PostTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
