using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    public class PaymentHistory : Common
    {
        [Column("AccountId")]
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("Code")]
        public string Code { get; set; } = null!;

        [Column("Status")]
        public Guid StatusId { get; set; }  // CONFIRMED, PENDING, CANCELLED
        public Status? Status { get; set; }
    }
}
