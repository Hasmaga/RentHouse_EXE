using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto
{
    public class CreatePriceUnitReqDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
