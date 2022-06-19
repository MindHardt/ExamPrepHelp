// See https://aka.ms/new-console-template for more information
using Helping;

string[] lines = File.ReadAllLines("data.csv");

Order[] orders = lines
    .Select(line => new Order(line))
    .ToArray();

foreach (Order order in orders)
{
    Console.WriteLine(order.ToString());
}
