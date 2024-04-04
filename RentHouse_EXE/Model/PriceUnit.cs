using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("PriceUnit", Schema = "dbo")]
    public class PriceUnit : Common
    {
        [Column("Name")]
        public string Name { get; set; } = null!;
        
        public ICollection<PostRealEstate>? PostRealEstates { get; set; }
    }
}
