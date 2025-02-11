using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YarnWebShop.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our Little Yarn Shop!\n");

        // Add sample products if they don't exist
        AddSampleProducts();

        // Display all products
        DisplayAllProducts();

        // Wait for user input before closing
        Console.ReadLine();
    }

    static void AddSampleProducts()
    {
        using (var context = new YarnShopDbContext())
        {
            // Check if there are any products already in the database
            if (!context.Products.Any())
            {
                // Add sample products
                context.Products.AddRange(
                    new Product { Name = "Red Yarn", Description = "Soft and warm red yarn", Price = 59.90m },
                    new Product { Name = "Blue Yarn", Description = "Cool blue yarn for projects", Price = 64.90m },
                    new Product { Name = "Green Yarn", Description = "Bright green yarn", Price = 49.90m }
                );

                // Save the changes to the database
                context.SaveChanges();

                Console.WriteLine("Sample products added to the database.");
            }

        }
    }
    static void DisplayAllProducts()
    {
        using (var context = new YarnShopDbContext())
        {
            // Get all products from the database
            var products = context.Products.ToList();

            Console.WriteLine("Products in stock:\n");
            Console.WriteLine("ID | Name          | Description                    | Price");
            Console.WriteLine("----------------------------------------------------------------");

            // Display product details in a formatted way
            foreach (var product in products)
            {
                // Using string formatting for neat output
                Console.WriteLine($"{product.ProductId,-2} | {product.Name,-13} | {product.Description,-30} | {product.Price,6:C}");
            }
        }
    }
}