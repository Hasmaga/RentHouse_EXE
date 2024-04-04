namespace RentHouse_EXE.Model.ResDto
{
    public class GetTitlePostRealEstateResDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Street { get; set; } = null!;
        public decimal Price { get; set; }
        public string? PriceUnit { get; set; } = null!;
        public string? Furniture { get; set; } = null!;
        public int TotalBathRoom { get; set; }
        public int TotalBedRoom { get; set; }
        public int TotalFloor { get; set; }
        public decimal Area { get; set; }
        public byte[]? ImageCover { get; set; }
    }
}
