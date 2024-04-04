using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("CommentRealEstate", Schema = "dbo")]
    public class CommentRealEstate : Common
    {
        [Column("ContentCommon")]
        public string ContentCommon { get; set; } = null!;

        [Column("PostRealEstateId")]
        public Guid PostRealEstateId { get; set; }
        public PostRealEstate? PostRealEstate { get; set; }

        [Column("AccountCommentId")]
        public Guid AccountCommentId { get; set; }
        public Account? AccountComment { get; set; }

        [Column("AdminCommentId")]
        public Guid? AdminCommentId { get; set; }
        public Account? AdminComment { get; set; }

        [Column("StatusId")]
        public Guid StatusId { get; set; }
        public Status? Status { get; set; }

        public ICollection<LikeComment> LikeComments { get; set; } = null!;
        public ICollection<ReplyComment> ReplyComments { get; set; } = null!;

    }
}
