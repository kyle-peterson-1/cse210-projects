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
        Customer customer1 = new Customer("Customer1", address1);

        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: {order1.CalculateTotalCost():C}");
    }
}

class Order
{
    public List<Product> Products { get; }
    public Customer Customer { get; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalPrice = Products.Sum(product => product.Price * product.Quantity);
        return Customer.IsInUSA() ? totalPrice + 5.00m : totalPrice + 35.00m;
    }

    public string GetPackingLabel()
    {
        return string.Join(Environment.NewLine, Products.Select(product => $"{product.Name} (ID: {product.ProductId})"));
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}{Environment.NewLine}{Customer.Address.GetFullAddress()}";
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
    public string StreetAddress {get; }
    public string City {get; }
    public string StateProvince {get; }
    public string Country {get; }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}
