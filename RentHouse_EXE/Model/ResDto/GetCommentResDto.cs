namespace RentHouse_EXE.Model.ResDto
{
    public class GetCommentResDto
    {
        public Guid Id { get; set; }
        public string ContentCommon { get; set; } = null!;
        public Guid RealEstateId { get; set; }        
        public DateTime CommentDateTime { get; set; }
        public string AccountCommentName { get; set; } = null!;       
        public int LikeCount { get; set; }        
    }
}
