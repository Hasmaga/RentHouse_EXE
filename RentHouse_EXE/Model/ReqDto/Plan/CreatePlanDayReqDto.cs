using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace RentHouse_EXE.Model.ReqDto.Plan
{
    public class CreatePlanDayReqDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Day must be a positive number")]
        public int Day { get; set; }
    }
}
