namespace HeliosTowers_Tests
{
    class Order
    {
        public required string CustomerName { get; set; }
        public required string Category { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderSummaryPrinter
    {
        public void PrintLinqResults()
        {
            var Orders = new List<Order>
            {
                new() { CustomerName = "Alice", Category = "Electronic", Amount = 200 },
                new() { CustomerName = "Alice", Category = "Book", Amount = 100 },
                new() { CustomerName = "Bob", Category = "Book", Amount = 150 }
            };

            var grouped = Orders
                .GroupBy(x => x.CustomerName)
                .Select(g => new
                {
                    Customer = g.Key,
                    Total = g.Sum(x => x.Amount),
                    Categories = g.GroupBy(x => x.Category)
                                  .Select(c => new
                                  {
                                      Category = c.Key,
                                      Total = c.Sum(x => x.Amount)
                                  })
                });

            foreach (var customer in grouped)
            {
                Console.WriteLine($"{customer.Customer} : {customer.Total}");
                foreach (var cat in customer.Categories)
                {
                    Console.WriteLine($"   - {cat.Category} : {cat.Total}");
                }
            }
        }
    }
}