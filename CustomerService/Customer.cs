namespace CustomerService
{
    public class Customer
    {
        public Customer(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }
}
