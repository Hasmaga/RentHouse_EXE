using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.Dto.Status
{
    public class UpdateStatus
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; } = null!;
    }
}
