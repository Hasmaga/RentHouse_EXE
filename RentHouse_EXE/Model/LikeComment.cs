using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("LikeComment", Schema = "dbo")]
    public class LikeComment : Common
    {
        [Column("CommentId")]
        public Guid? CommentId { get; set; }
        public CommentRealEstate? CommentRealEstate { get; set; }

        [Column("ReplyCommentId")]
        public Guid? ReplyCommentId { get; set; }
        public ReplyComment? ReplyComment { get; set; }

        [Column("AccountLikeCommentId")]
        public Guid AccountLikeCommentId { get; set; }
        public Account AccountLikeComment { get; set; } = null!;        
    }
}
