namespace Foundation2;

using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Customer customer1 = new Customer(
            "Isahi Torres",
            new Address("253 S 5TH E", "Rexburg", "ID", "USA")
        );

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "KB101", 49.99, 1));
        order1.AddProduct(new Product("Mouse", "MS202", 19.99, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine("\n------------------------------\n");

        // Order 2 (International)
        Customer customer2 = new Customer(
            "Ana Lopez",
            new Address("10 Reforma", "Mexico City", "CDMX", "Mexico")
        );

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headset", "HD303", 79.99, 1));
        order2.AddProduct(new Product("Webcam", "WC404", 39.99, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalPrice():0.00}");
    }
}
