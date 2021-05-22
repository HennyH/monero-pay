namespace MoneroPay.Database
{
    public class Account
    {
        public int Id { get; set; }
        public int Salt { get; set; }
        public string? PasswordHash { get; set; }
    }
}