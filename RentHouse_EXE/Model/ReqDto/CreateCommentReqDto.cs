using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto
{
    public class CreateCommentReqDto
    {
        [Required]
        public Guid PostRealEstateId { get; set; }

        [Required]
        public string ContentCommon { get; set; } = null!;
    }
}
