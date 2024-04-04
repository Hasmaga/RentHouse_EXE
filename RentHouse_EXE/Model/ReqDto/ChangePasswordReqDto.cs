using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto
{
    public class ChangePasswordReqDto
    {
        [Required]
        public string OldPassword { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;
    }
}
