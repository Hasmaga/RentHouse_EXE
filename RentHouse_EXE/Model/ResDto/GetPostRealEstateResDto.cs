using System.Reflection.Metadata;

namespace RentHouse_EXE.Model.ResDto
{
    public class GetPostRealEstateResDto
    {        
        public string TypeRealEstate { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ContactName { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public decimal Price { get; set; }
        public string PriceUnit { get; set; } = null!;
        public string Furniture { get; set; } = null!;
        public int TotalRoom { get; set; }
        public int TotalBathRoom { get; set; }
        public int TotalBedRoom { get; set; }
        public int TotalFloor { get; set; }
        public decimal Area { get; set; }
        public DateOnly PostDay { get; set; }
        public List<GetListImagaeResDto>? Images { get; set; }
    }
}
