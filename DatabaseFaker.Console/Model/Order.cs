namespace DatabaseFaker.Console.Model;

internal class Order
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public int TotalCost { get; set; }
    public DateTime TimeOrdered { get; set; }
    public string FromCompany { get; set; }
    public int NumberOfItems { get; set; }
    public string Material { get; set; }
}