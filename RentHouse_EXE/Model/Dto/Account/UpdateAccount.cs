using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RentHouse_EXE.Model.Dto.Account
{
    public class UpdateAccount
    {        

        [StringLength(50, MinimumLength =1)]
        public string? FirstName { get; set; } = null;

        [StringLength(50, MinimumLength = 1)]
        public string? LastName { get; set; } = null;

        [StringLength(50, MinimumLength = 1)]
        public string? Password { get; set; } = null;

        [StringLength(10, MinimumLength =10)]
        public string? PhoneNumber { get; set; } = null;
        
        public Guid? StatusId { get; set; } = null;

        public Guid? RoleId { get; set; } = null;

        public DateTime? DeteleDateTime { get; set; } = null;

        public DateTime UpdateDateTime { get; set; } = DateTime.Now;

    }
}
