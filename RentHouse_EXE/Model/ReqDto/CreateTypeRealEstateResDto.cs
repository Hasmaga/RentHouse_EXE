using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto
{
    public class CreateTypeRealEstateResDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
