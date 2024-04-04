using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto.Plan
{
    public class CreatePriceDescreaseReqDto
    {
        [Required]
        public Guid PriceDayId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "PercentageDescrease must be in the range of 0 to the maximum value of decimal")]
        public decimal PercentageDescrease { get; set; }
    }
}
