using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("TypeRealEstate", Schema = "dbo")]
    public class TypeRealEstate : Common
    {
        [Column("Name")]
        public string Name { get; set; } = null!;

        [Column("Description")]
        public string Description { get; set; } = null!;

        public ICollection<PostRealEstate> PostRealEstates { get; set; } = null!; // Sell, Rent
    }
}
