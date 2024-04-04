using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("Role", Schema = "dbo")]
    public class Role : Common
    {
        [Column("RoleName")]
        public string RoleName { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = null!;
    }
}
