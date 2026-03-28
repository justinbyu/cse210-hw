using System;

class Program
{
    static void Main(string[] args)
    {
        // -------- ORDER 1 --------
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P002", 20, 2));

        // -------- ORDER 2 --------
        Address address2 = new Address("456 Rizal St", "Manila", "NCR", "Philippines");
        Customer customer2 = new Customer("Juan Dela Cruz", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P003", 500, 1));
        order2.AddProduct(new Product("Charger", "P004", 25, 2));
        order2.AddProduct(new Product("Earphones", "P005", 15, 3));

        // -------- DISPLAY --------
        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        Console.WriteLine("\n-----------------\n");

        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}