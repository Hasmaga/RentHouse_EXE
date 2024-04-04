namespace RentHouse_EXE.Model.Dto.Account
{
    public class GetAllAccount
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public string? Role { get; set; }
    }
}
