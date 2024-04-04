using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Status
{
    public class CreateStatus
    {
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; } = null!;
    }
}
