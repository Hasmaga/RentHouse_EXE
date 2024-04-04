using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("PlanPrice", Schema = "dbo")]
    public class PlanPrice : Common
    {
        [Column("PlanId")]
        public Guid PlanId { get; set; }
        public Plan? Plans { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }     
        
        public ICollection<PostRealEstate> PostRealEstates { get; set; } = null!;
    }
}
