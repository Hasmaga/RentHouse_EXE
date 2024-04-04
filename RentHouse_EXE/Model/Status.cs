using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("Status", Schema = "dbo")]
    public class Status : Common
    {
        [Column("StatusName")]
        public string StatusName { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = null!;
        public ICollection<CommentRealEstate> CommentRealEstates { get; set; } = null!;
        public ICollection<ImageRealEstate> ImageRealEstates { get; set; } = null!;
        public ICollection<PostRealEstate> PostRealEstates { get; set;} = null!;
        public ICollection<ReplyComment> ReplyComments { get; set; } = null!;
    }
}
