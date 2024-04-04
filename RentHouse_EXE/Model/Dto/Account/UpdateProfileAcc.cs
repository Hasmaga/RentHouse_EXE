using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Account
{
    public class UpdateProfileAcc
    {
        [StringLength(50, MinimumLength = 1)]
        public string? FirstName { get; set; } = null;

        [StringLength(50, MinimumLength = 1)]
        public string? LastName { get; set; } = null;

        [StringLength(50, MinimumLength = 1)]
        public string? Password { get; set; } = null;

        [StringLength(10, MinimumLength = 10)]
        public string? PhoneNumber { get; set; } = null;
    }
}
