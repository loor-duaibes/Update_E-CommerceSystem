using Business_Layer.Interfaces;
using Business_Layer.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Data_Layer.DataModel;
using Business_Layer.Services;
using Data_Layer.Repos;

namespace E_Commerce
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("log/logs.txt",rollingInterval:RollingInterval.Day)
                .CreateLogger();

            Log.Information("Starting up the e-commerce system.......");
           // Create Products
            Product product1 = new Product(1, "Laptop", 3000.0);
            Product product2 = new Product(2, "SmartWatch", 1200.0);
            Product product3 = new Product(3, "Router", 650.0);
            Product product4 = new Product(4, "TV", 2500.0);
            Product product5 = new Product(5, "Hardware", 1600.0);

            // Create Customer
            Customer customer = new Customer(1, "Loor");

            // Add Products to Shopping Cart
            customer.AddToCart(product1);
            customer.AddToCart(product2);
            customer.AddToCart(product3);
            customer.AddToCart(product4);
            customer.AddToCart(product5);


            Order order = customer.PlaceOrder();

            IPayment payment = new CreditCardPayment();
            payment.ProcessPayment(order.CalculateOrder());

            Console.WriteLine("Customer ID : " + customer.Id + " , Customer Name : " + customer.Name);
            Console.WriteLine("Products: ");
            List<Product> products = new List<Product>(customer.Cart.products);

            foreach (Product product in products)
            {
                Console.Write("Product " + product.ProductID + " -> ");
                product.GetProductInfo();
                Console.WriteLine("");
            }

            Console.WriteLine("=======================");
            Console.WriteLine("After Remove first Product");
            customer.RemoveFromCart(product1);
            foreach (Product product in customer.Cart.products)
            {
                Console.Write("Product " + product.ProductID + " -> ");
                product.GetProductInfo();
                Console.WriteLine("");
            }
            Console.WriteLine("Boxing and Unboxing");
            /*int quantity = 10;
            order.Demonstrate(quantity);*/
            Order order2 = new Order(customer, products, 3);
            Console.WriteLine("Quantity of Products : " + order2.GetQuantity());
            Console.WriteLine("=========================");
            order2.SaveToJSONFile("C:\\Users\\GhRepair\\source\\repos\\E-Commerce\\order.json");
            Console.WriteLine("Read From JSON File");
            order2.LoadFromJSONFile("C:\\Users\\GhRepair\\source\\repos\\E-Commerce\\order.json");

            ProductService productService = new ProductService();
            OrderService orderService = new OrderService();

            List<Product> productss = productService.GetAllProducts("C:\\Users\\GhRepair\\source\\repos\\E-Commerce\\order.json");
            if(productss == null)
            {
                Log.Error("No Product to return");
                return;
            }
            foreach (var product in productss)
            {
                Console.WriteLine($"{product.ProductID} - {product.ProductName} - ${product.ProductPrice}");
            }

            // Simulate placing an order
            Customer customerr = new Customer { Name = "Yaman" };

            if (productss != null && productss.Count > 0 && customerr.Cart != null)
            {
                customerr.Cart.AddProduct(productss[0]); 
            }
            else
            {
                Log.Error("No products available to add to the cart.");
            }

            orderService.PlaceOrder(customerr, customerr.Cart);
         

            Log.CloseAndFlush();
        }
    }
}
