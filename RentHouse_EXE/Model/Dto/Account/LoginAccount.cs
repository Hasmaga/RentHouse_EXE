using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Account
{
    public class LoginAccount
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; } = null!;
    }
}
