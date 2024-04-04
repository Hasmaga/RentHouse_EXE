namespace RentHouse_EXE.Model.ResDto
{
    public class GetReplyCommentResDto
    {
        public Guid Id { get; set; }
        public string ContentReply { get; set; } = null!;
        public DateTime ReplyDateTime { get; set; }
        public string AccountReplyName { get; set; } = null!;
        public int LikeCount { get; set; }
        public ICollection<GetReplyCommentResDto> ReplyComments { get; set; } = new List<GetReplyCommentResDto>();
    }
}
