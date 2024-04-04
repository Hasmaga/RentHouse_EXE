namespace RentHouse_EXE.Model.ResDto
{
    public class GetAccountResDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public decimal Wallet { get; set; }
    }
}
