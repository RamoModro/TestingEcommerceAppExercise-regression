namespace TestingEcommerceAppExercise.Helpers.Models;

public class ShippingDetails
{
    public string Email { get; set; } = Faker.Internet.Email();
    public string FirstName { get; set; } = Faker.Name.First();
    public string LastName { get; set; } = Faker.Name.Last();
    public string Country { get; set; } = "Romania";
    public string StreetAddress { get; set; } = Faker.Name.Last();
    public string City { get; set; } = "Cluj-Napoca";
    public string StateProvince { get; set; } = "Cluj";
    public string PostalCode { get; set; } = Faker.RandomNumber.Next(111111, 999999).ToString();
    public string PhoneNumber { get; set; } = "123456789";
}
