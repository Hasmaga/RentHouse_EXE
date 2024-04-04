using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Role
{
    public class CreateRole
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; } = null!;
    }
}
