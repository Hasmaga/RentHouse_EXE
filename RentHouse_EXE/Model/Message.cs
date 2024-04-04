using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("Message", Schema = "dbo")]
    public class Message : Common
    {
        [Column("CustomerSendId")]
        public Guid CustomerSendId { get; set; }
        public Account CustomerSend { get; set; } = null!;

        [Column("CustomerReceiveId")]
        public Guid CustomerReceiveId { get; set; }
        public Account CustomerReceive { get; set; } = null!;

        [Column("Content")]
        public string Content { get; set; } = null!;

        [Column("Status")]
        public bool Status { get; set; }
    }
}
