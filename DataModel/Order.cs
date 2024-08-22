using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data_Layer.DataModel
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered
    }
    public class Order 
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public object Quantity { get; set; }

        public Order() { }

        public Order(Customer customer, List<Product> products)
        {
            Customer = customer;
            Products = new List<Product>(products);
        }
        public Order(Customer customer, List<Product> products, int quantity)
        {
            Customer = customer;
            Products = new List<Product>(products);
            Quantity = quantity;
        }
        public Order(Customer customer, List<Product> products, DateTime date, OrderStatus status, int quantity)
        {
            Customer = customer;
            Products = new List<Product>(products);
            OrderDate = date;
            Status = status;
            Quantity = quantity; //Boxing
        }
        public int GetQuantity()
        {
            return (int)Quantity; //Unboxing
        }
        public double ApplyDiscount(double discount)
        {
            return discount * 0.9;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public double CalculateOrder()
        {
            Log.Information("Calculate all products ");
            double sum = 0;
            foreach (Product product in Products)
            {
                sum += product.ProductPrice;
            }
            return sum;
        }
        /*public void Demonstrate(int quantity)
        {
            Object BoxingQuantity = quantity; // Boxing
            int UnboxingQuantity = (int)BoxingQuantity; // Unboxing
            Console.WriteLine("Boxing Quantity : " + BoxingQuantity + " and Unboxing Quantity : " + UnboxingQuantity);
         }*/

        //Method to Serialize an order to a JSON File
        public void SaveToJSONFile(string Filename)
        {
            try
            {
                if (Products == null)
                {
                    Console.WriteLine("No products to save.");
                    return;
                }
                string jsonString = JsonSerializer.Serialize(Products);
                File.WriteAllText(Filename, jsonString);
                Console.WriteLine("Order data has been saved to json file");

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (JsonException e)
            {
                Console.WriteLine("Error saving data to json file");
            }

        }
        // Method to Deserialization
        public void LoadFromJSONFile(string Filename)
        {
            try
            {
                string jsonString = File.ReadAllText(Filename);
                Console.WriteLine(jsonString);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (JsonException e)
            {
                Console.WriteLine("Error loading data to json file");
            }

        }
    }


}
