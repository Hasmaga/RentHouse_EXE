using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model.Provinces
{
    [Table("wards", Schema = "dbo")]
    public class Wards
    {
        [Column("code")]
        public string Code { get; set; } = null!;

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("name_en")]
        public string? Name_en { get; set; }

        [Column("full_name")]
        public string? Full_name { get; set; }

        [Column("full_name_en")]
        public string? Full_name_en { get; set; }

        [Column("code_name")]
        public string? Code_name { get; set; }

        [Column("district_code")]
        public string? District_code { get; set; }
        public Districts? Districts { get; set; }

        [Column("administrative_unit_id")]
        public int? Administrative_unit_id { get; set; }
        public Administrative_units? Administrative_units { get; set; }        
    }
}
