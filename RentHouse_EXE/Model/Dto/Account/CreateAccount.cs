using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Account
{
    public class CreateAccount
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; } = null!;

        // Phone number have to be 10 digits        
        [StringLength(10, MinimumLength = 10)]
        [Phone]
        public string? PhoneNumber { get; set; } = null;

    }
}
