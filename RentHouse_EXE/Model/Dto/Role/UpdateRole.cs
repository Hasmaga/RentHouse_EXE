using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Role
{
    public class UpdateRole
    {
        [Required]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(50)]       
        public string RoleName { get; set; } = null!;
    }
}
