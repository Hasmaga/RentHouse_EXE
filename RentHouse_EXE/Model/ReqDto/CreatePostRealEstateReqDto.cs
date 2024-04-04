using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto
{
    public class CreatePostRealEstateReqDto
    {
        public Guid TypeId { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Area { get; set; }
        public decimal Price { get; set; }
        public Guid PriceUnitId { get; set; }
        public Guid FurnitureId { get; set; } 
        public int BedRoom { get; set; }
        public int BathRoom { get; set; }
        public int Floor { get; set; }
        public string ContactName { get; set; } = null!;
        [Phone]
        public string ContactPhone { get; set; } = null!;
        [EmailAddress]
        public string ContactEmail { get; set; } = null!;       
        public Guid PlanId { get; set; }
        public Guid PlanDayId { get; set; }
        public DateOnly PostDate { get; set; } 
        public TimeOnly PostTime { get; set; }
    }
}
