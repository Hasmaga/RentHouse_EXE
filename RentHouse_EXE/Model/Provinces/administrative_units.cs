using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model.Provinces
{
    [Table("administrative_units", Schema = "dbo")]
    public class Administrative_units
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        [MaxLength(255)]
        public string? Full_name { get; set; }

        [Column("full_name_en")]
        [MaxLength(255)]
        public string? Full_name_en { get; set; }

        [Column("short_name")]
        [MaxLength(255)]
        public string? Short_name { get; set; }

        [Column("short_name_en")]
        [MaxLength(255)]
        public string? Short_name_en { get; set; }

        [Column("code_name")]
        [MaxLength(255)]
        public string? Code_name { get; set; }

        [Column("code_name_en")]
        [MaxLength(255)]
        public string? Code_name_en { get; set; }        

        public ICollection<Provinces>? Provinces { get; set; }
        public ICollection<Districts>? Districts { get; set; }
        public ICollection<Wards>? Wards { get; set; }
    }
}
