namespace HeliosTowers_Tests
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public interface ICustomerRepository
    {
        void Add(Customer c);
        Customer Get(int id);
        void Update(Customer c);
        void Delete(int id);
        IEnumerable<Customer> GetAll();
    }

    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private Dictionary<int, Customer> _data = [];

        public void Add(Customer c) => _data[c.Id] = c;
        public Customer? Get(int id)
        {
            return _data.ContainsKey(id) ? _data.GetValueOrDefault(id) : throw new KeyNotFoundException("Given key not found!.");
        }
        public void Update(Customer c) => _data[c.Id] = c;
        public void Delete(int id) => _data.Remove(id);
        public IEnumerable<Customer> GetAll() => _data.Values;
    }
}