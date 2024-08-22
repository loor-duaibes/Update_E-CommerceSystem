using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data_Layer.DataModel;
using Serilog;

namespace Data_Layer.Repos
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts(string filename)
        {
            List<Product> products = new List<Product>();
            try
            {
                string jsonString = File.ReadAllText(filename);
                products = JsonSerializer.Deserialize<List<Product>>(jsonString);
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                Log.Error("Error reading data from Json File");
            }
            return products;

        }
        public void AddProduct(Product product, string filename)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(product);
                File.WriteAllText(jsonString, filename);
            }
            catch(JsonException ex) 
            { 
                Console.WriteLine("Error adding product to json file.....");
                Log.Error("Error wriring data to Json File");
            }
        }
    }
}
