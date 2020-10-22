namespace Core.Models
{
    public class Customer
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public string CurrentAddress { get; set; }
        public string BillingAddress { get; set; }

    }
}