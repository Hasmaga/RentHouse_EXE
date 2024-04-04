using RentHouse_EXE.Model.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHouse_EXE.Model
{
    [Table("Account", Schema ="dbo")]
    public class Account : Common
    {
        [Column("FirstName")]
        public string FirstName { get; set; } = null!;

        [Column("LastName")]
        public string LastName { get; set; } = null!;

        [Column("Email")]
        public string Email { get; set; } = null!;

        [Column("PasswordHash")]
        public string PasswordHash { get; set; } = null!;

        [Column("PasswordSalt")]
        public string PasswordSalt { get; set; } = null!;

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; } = null;

        [Column("StatusId")]
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;

        [Column("RoleId")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        [Column("Wallet")]
        public decimal Wallet { get; set; } = 0;

        public ICollection<CommentRealEstate> AccountComments { get; set; } = null!;
        public ICollection<CommentRealEstate> AdminComments { get; set; } = null!;
        public ICollection<LikeComment> AccountLikeComment { get; set; } = null!;
        public ICollection<Message> CustomerSends { get; set; } = null!;
        public ICollection<Message> CustomerReceives { get; set; } = null!;
        public ICollection<PostRealEstate> CustomerPosts { get; set; } = null!;
        public ICollection<PostRealEstate> AdminPosts { get; set; } = null!;
        public ICollection<ReplyComment> AccountReplyComments { get; set; } = null!;
    }
}
