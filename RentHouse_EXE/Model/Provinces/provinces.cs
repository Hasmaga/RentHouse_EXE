﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model.Provinces
{
    [Table("provinces", Schema = "dbo")]
    public class Provinces
    {
        [Column("code")]
        [MaxLength(20)]
        public string Code { get; set; } = null!;

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Column("name_en")]
        [MaxLength(255)]
        public string? Name_en { get; set; }

        [Column("full_name")]
        [MaxLength(255)]
        public string Full_name { get; set; } = null!;

        [Column("full_name_en")]
        [MaxLength(255)]
        public string? Full_name_en { get; set; }

        [Column("code_name")]
        [MaxLength(255)]
        public string? Code_name { get; set; }

        [Column("administrative_unit_id")]        
        public int? Administrative_unit_id { get; set; }
        public Administrative_units? Administrative_units { get; set; }

        [Column("administrative_region_id")]        
        public int? Administrative_region_id { get; set; }
        public Administrative_regions? Administrative_regions { get; set; }
        
        public ICollection<Districts>? Districts { get; set; }
    }
}
