using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto
{
    public class CreateReplyCommentReqDto
    {
        [Required]
        public Guid CommentId { get; set; }

        [Required]
        public string ContentReply { get; set; } = null!;
    }
}
