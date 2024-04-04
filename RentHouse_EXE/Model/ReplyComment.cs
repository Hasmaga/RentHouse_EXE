using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("ReplyComment", Schema = "dbo")]
    public class ReplyComment : Common
    {
        [Column("ReplyCommentContent")]
        public string ReplyCommentContent { get; set; } = null!;

        [Column("CommentId")]
        public Guid? CommentId { get; set; }
        public CommentRealEstate CommentRealEstate { get; set; } = null!;

        [Column("AccountReplyCommentId")]
        public Guid AccountReplyCommentId { get; set; }
        public Account AccountReplyComment { get; set; } = null!;

        [Column("StatusId")]
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;
        
        [Column("ParentReplyCommentId")]
        public Guid? ParentReplyCommentId { get; set; }
        public ReplyComment ParentReplyComment { get; set; } = null!;

        public ICollection<ReplyComment> ReplyComments { get; set; } = null!;
        public ICollection<LikeComment> LikeComments { get; set; } = null!;        
    }
}
