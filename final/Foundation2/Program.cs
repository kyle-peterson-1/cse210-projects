//Program 2: Encapsulation with Online Ordering

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Product product1 = new Product("Product1", 1, 10.99m, 2);
        Product product2 = new Product("Product2", 2, 5.99m, 3);

        Address address1 = new Address("123 Main St", "City1", "State1", "USA");
        Address address2 = new Address("456 Oak St", "City2", "State2", "Canada");

        Customer customer1 = new Customer("John Peterson", address1);
        Customer customer2 = new Customer("Braden Sherwood", address2);

        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product2 }, customer2);

        Console.WriteLine("Order 1:");
        Console.WriteLine($"Packing Label:{Environment.NewLine}{order1.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:{Environment.NewLine}{order1.GetShippingLabel()}");
        Console.WriteLine($"Total Price: {order1.CalculateTotalCost():C}");
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine($"Packing Label:{Environment.NewLine}{order2.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:{Environment.NewLine}{order2.GetShippingLabel()}");
        Console.WriteLine($"Total Price: {order2.CalculateTotalCost():C}");
    }
}

class Order
{
    private readonly List<Product> products;
    private readonly Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalPrice = products.Sum(product => product.Price * product.Quantity);
        return customer.IsInUSA() ? totalPrice + 5.00m : totalPrice + 35.00m;
    }

    public string GetPackingLabel()
    {
        return string.Join(Environment.NewLine, products.Select(product => $"{product.Name} (ID: {product.ProductId})"));
    }

    public string GetShippingLabel()
    {
        return $"{customer.Name}{Environment.NewLine}{customer.Address.GetFullAddress()}";
    }
}

class Product
{
    public string Name {get; }
    public int ProductId {get; }
    public decimal Price {get; }
    public int Quantity {get; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}

class Customer
{
    public string Name {get; }
    public Address Address {get; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Address
{
    private readonly string streetAddress;
    private readonly string city;
    private readonly string stateProvince;
    private readonly string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {stateProvince}, {country}";
    }
}
