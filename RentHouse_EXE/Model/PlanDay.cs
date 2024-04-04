using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("PlanDay", Schema = "dbo")]
    public class PlanDay : Common
    {
        [Column("Day")]
        public int Day { get; set; }

        public ICollection<PriceDecreases>? PriceDecreaseses { get; set; }        
    }
}
