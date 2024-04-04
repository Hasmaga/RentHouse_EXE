using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("Plan", Schema = "dbo")]
    public class Plan : Common
    {
        [Column("Name")]
        public string Name { get; set; } = null!;

        public ICollection<PlanPrice>? PlanPrices { get; set; }        
    }
}
