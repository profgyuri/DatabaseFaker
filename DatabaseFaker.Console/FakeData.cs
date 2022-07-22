namespace DatabaseFaker.Console;

using Bogus;
using System.Security.Cryptography;

internal class FakeData
{
    private const int minPeople = 50000;
    private const int maxPeople = 100000;

    internal List<Model.Person> People { get; set; } = new();
    internal List<Model.Order> Orders { get; set; } = new();

    internal FakeData()
    {
        var peopleFaker = new Faker<Model.Person>()
           .RuleFor(p => p.Id, _ => Guid.NewGuid())
           .RuleFor(p => p.Country, f => f.Address.Country())
           .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
           .RuleFor(p => p.Street, f => f.Address.StreetName())
           .RuleFor(p => p.City, f => f.Address.City())
           .RuleFor(p => p.HouseNumber, f => f.Address.BuildingNumber())
           .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
           .RuleFor(p => p.Name, f => f.Name.FullName())
           .RuleFor(p => p.UserName, f => f.Internet.UserName());

        var people = peopleFaker.GenerateBetween(minPeople, maxPeople);
        People.AddRange(people);

        var ordersFaker = new Faker<Model.Order>()
           .RuleFor(o => o.Id, _ => Guid.NewGuid())
           .RuleFor(o => o.TotalCost, _ => RandomNumberGenerator.GetInt32(100, 5000))
           .RuleFor(o => o.NumberOfItems, _ => RandomNumberGenerator.GetInt32(1, 75))
           .RuleFor(o => o.Material, (f, o) => f.Commerce.ProductMaterial())
           .RuleFor(o => o.TimeOrdered, f => f.Date.Past(13, DateTime.Now))
           .RuleFor(o => o.FromCompany, f => f.Company.CompanyName())
           .RuleFor(o => o.PersonId, f => f.PickRandom(People).Id);

        var orders = ordersFaker.GenerateBetween(People.Count * 2, People.Count * 5);
        Orders.AddRange(orders);
    }
}