using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("Furniture", Schema = "dbo")]
    public class Furniture : Common
    {
        [Column("Name")]
        public string Name { get; set; } = null!;
        
        public ICollection<PostRealEstate>? PostRealEstates { get; set; }
    }
}
