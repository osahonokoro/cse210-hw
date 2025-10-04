using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First Order (USA)
        Address address1 = new Address("123 Apple St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        List<Product> products1 = new List<Product>
        {
            new Product("Laptop", "P001", 999.99, 1),
            new Product("Mouse", "P002", 25.50, 2)
        };

        Order order1 = new Order(customer1, products1);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Second Order (International)
        Address address2 = new Address("456 Mango Ave", "Lagos", "Lagos", "Nigeria");
        Customer customer2 = new Customer("Jane Smith", address2);

        List<Product> products2 = new List<Product>
        {
            new Product("Tablet", "P003", 499.99, 1),
            new Product("Stylus", "P004", 45.00, 1),
            new Product("Case", "P005", 30.00, 1)
        };

        Order order2 = new Order(customer2, products2);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
