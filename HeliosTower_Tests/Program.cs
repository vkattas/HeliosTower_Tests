// See https://aka.ms/new-console-template for more information
using HeliosTowers_Tests;

Console.WriteLine("Helios Tower Tests");

Console.WriteLine("Test 1 Results");
var printer = new OrderSummaryPrinter();
printer.PrintLinqResults();

Console.WriteLine("Test 2 -> Design Changes");
ILogger logger = new FileLogger();
logger.Log("App started.");

Console.WriteLine("Test 3 -> In Memory Data Updates");
ICustomerRepository crp = new InMemoryCustomerRepository();
//Add new customer 
crp.Add(new Customer { Id = 1, Name = "Alice" });
crp.Add(new Customer { Id = 2, Name = "Gama" });

var customers = crp.GetAll();
Console.WriteLine("Customers List");
foreach (var cust in customers)
{
    Console.WriteLine($"{cust.Id}: {cust.Name}");
}

//Get the customer 
var customer = crp.Get(1) ?? throw new Exception("issue");
//Update customer
customer.Name = "Bob";
crp.Update(customer);

//Delete customer Gama
crp.Delete(2);

