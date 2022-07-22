namespace DatabaseFaker.Console;

using Microsoft.EntityFrameworkCore;
using DatabaseFaker.Console.Model;

internal class DataContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=practice;Integrated Security=True");
    }
}