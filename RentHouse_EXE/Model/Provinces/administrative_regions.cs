using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model.Provinces
{
    [Table("administrative_regions", Schema = "dbo")]
    public class Administrative_regions
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]        
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Column("name_en")]
        [MaxLength(255)]
        public string Name_en { get; set; } = null!;

        [Column("code_name")]
        [MaxLength(255)]
        public string? Code_name { get; set; } 

        [Column("code_name_en")]
        [MaxLength(255)]
        public string? Code_name_en { get; set; }      

        public ICollection<Provinces> Provinces { get; set; } = null!;        
    }
}
