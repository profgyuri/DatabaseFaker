namespace DatabaseFaker.Console;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new DataContext();
        var faker = new FakeData();

        System.Console.WriteLine("Recreating database...");
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        System.Console.WriteLine("Adding people...");
        context.People.AddRange(faker.People);

        System.Console.WriteLine("Generating orders...");
        context.Orders.AddRange(faker.Orders);

        System.Console.WriteLine("Saving to database...");
        context.SaveChanges();

        System.Console.WriteLine();
        System.Console.WriteLine("Done!");
    }
}
