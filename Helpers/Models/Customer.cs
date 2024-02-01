using Faker;

namespace TestingEcommerceAppExercise.Helpers.Models
{
    public class Customer
    {
        public string FirstName { get; set; } = Name.First();
        public string LastName { get; set; } = Name.Last();
        public string Email { get; set; } = Internet.Email();
        public string Password { get; set; } = "3vq4.mQJqx2QZfK";
    }
}
