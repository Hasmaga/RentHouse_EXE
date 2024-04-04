using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("ImageRealEstate", Schema = "dbo")]
    public class ImageRealEstate : Common
    {
        [Column("Image")]
        public byte[] Image { get; set; } = null!;

        [Column("PostRealEstateId")]
        public Guid PostRealEstateId { get; set; }
        public PostRealEstate PostRealEstate { get; set; } = null!;

        [Column("StatusId")]
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;       
    }
}
