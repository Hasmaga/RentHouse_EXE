using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("PostRealEstate", Schema = "dbo")]
    public class PostRealEstate : Common
    {
        [Column("Name")]
        public string Name { get; set; } = null!;

        [Column("TypeRealEstateId")]
        public Guid TypeRealEstateId { get; set; }
        public TypeRealEstate TypeRealEstates { get; set; } = null!;

        [Column("Address")]
        public string Address { get; set; } = null!;

        [Column("City")]
        public string City { get; set; } = null!;

        [Column("District")]
        public string District { get; set; } = null!;

        [Column("Ward")]
        public string Ward { get; set; } = null!;

        [Column("Street")]
        public string Street { get; set; } = null!;        

        [Column("CustomerPostId")]
        public Guid CustomerPostId { get; set; }
        public Account CustomerPosts { get; set; } = null!;

        [Column("AdminPostId")]
        public Guid? AdminPostId { get; set; }
        public Account AdminPosts { get; set; } = null!;

        [Column("StatusId")]
        public Guid StatusId { get; set; }
        public Status Statuses { get; set; } = null!;

        [Column("Description")]
        public string Description { get; set; } = null!;

        [Column("ContactName")]
        public string ContactName { get; set; } = null!;

        [Column("ContactEmail")]
        [EmailAddress]
        public string ContactEmail { get; set; } = null!;

        [Column("Phone")]
        [Phone]
        public string Phone { get; set; } = null!;

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("PriceUnit")]
        public Guid PriceUnitId { get; set; }
        public PriceUnit PriceUnits { get; set; } = null!;

        [Column("Furniture")]
        public Guid FurnitureId { get; set; }
        public Furniture Furnitures { get; set; } = null!;

        [Column("TotalRoom")]
        public int TotalRoom { get; set; }

        [Column("TotalBathRoom")]
        public int TotalBathRoom { get; set; }

        [Column("TotalBedRoom")]
        public int TotalBedRoom { get; set; }

        [Column("TotalFloor")]
        public int TotalFloor { get; set; }

        [Column("Area")]
        public decimal Area { get; set; }

        [Column("PlanPriceId")]
        public Guid PlanPriceId { get; set; }
        public PlanPrice PlanPrice { get; set; } = null!;

        [Column("PlanDayId")]
        public Guid PlanDayId { get; set; }
        public PlanDay PlanDay { get; set; } = null!;

        [Column("PostDate")]
        public DateOnly PostDate { get; set; }

        [Column("PostTime")]
        public TimeOnly PostTime { get; set; }

        [Column("TotalPrice")]
        public decimal TotalPrice { get; set; }

        public ICollection<ImageRealEstate> ImageRealEstates { get; set; } = null!;
        public ICollection<CommentRealEstate> CommentRealEstates { get; set; } = null!;

    }
}
