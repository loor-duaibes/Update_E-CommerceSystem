using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.DataModel
{
    public class ShoppingCart
    {
        public List<Product> products { get; set; }
        public Customer owner { get; set; }

        public ShoppingCart() { }
        public ShoppingCart(Customer customer)
        {
            owner = customer;
            products = new List<Product>(); // Tight Coupling
        }
        public void AddProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    products.Add(product);
                    Console.WriteLine("Add Product to Cart");
                }
                else { return; }
               

            }catch(Exception e) { Console.WriteLine(e); }
            
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
    }
}
