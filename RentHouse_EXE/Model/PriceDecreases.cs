using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("PriceDecreases", Schema = "dbo")]
    public class PriceDecreases : Common
    {
        [Column("PlanDayId")]
        public Guid PlanDayId { get; set; }
        public PlanDay? PlanDays { get; set; }

        [Column("PercentageDecrease")]
        public decimal PercentageDecrease { get; set; }        
    }
}
