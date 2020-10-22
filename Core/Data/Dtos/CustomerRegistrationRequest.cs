namespace Core.Dtos
{
    public class CustomerRegistrationRequest
    {
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CurrentAddress { get; set; }
        public string BillingAddress { get; set; }
    }
}
