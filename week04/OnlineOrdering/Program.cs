using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Order #1");
        Order order1 = new Order();
        order1.AddCustomer("Raul Rosales", "Santa Ana", "San Juan", "Chimaltenango", "Guatemala");
        order1.AddProduct("IPhone 17 Pro Max Case", "IP17PMC", 5.59, 1);
        order1.AddProduct("Carpet and Upholstery Deep Cleaner", "CUDC", 88.99, 1);
        order1.AddProduct("Baby Monitor", "BM", 89.99, 3);

        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total: ${order1.Total():F2}");
        Console.WriteLine("---------------------------------------------------------------------");

        Console.WriteLine("Order #2");
        Order order2 = new Order();
        order2.AddCustomer("Matthew Fry", "North Spruce Ave", "Protland", "OR", "US");
        order2.AddProduct("High Pressure Rain Shower Head", "HPRSH", 47.47, 1);
        order2.AddProduct("9-in-1 TurboBlaze Air Fryer", "TBAF", 89.89, 1);
        order2.AddProduct("Air Purifiers", "AP", 159.90, 2);

        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total: ${order2.Total():F2}");
        Console.WriteLine("---------------------------------------------------------------------");

        Console.WriteLine("Order #3");
        Order order3 = new Order();
        order3.AddCustomer("Edgar Morataya", "El Negrito", "La Parca", "San Miguel", "El Salvador");
        order3.AddProduct("5500 Series Fully Automatic Espresso Machine", "SFAEM", 1299.99, 2);
        order3.AddProduct("Samsung Galaxy Z Fold7", "SGZF7", 2119.99, 3);
        order3.AddProduct("DEEBOT X11 OmniCyclone Robot Vacuum and Mop", "D11CRVM", 1499.99, 3);

        Console.WriteLine(order3.PackingLabel());
        Console.WriteLine(order3.ShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total: ${order3.Total():F2}");
    }
}