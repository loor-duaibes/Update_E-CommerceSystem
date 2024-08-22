using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.DataModel
{
    public class Customer : Person
    {
        public ShoppingCart Cart { get; set; }
        public Customer() 
        { 
            Cart = new ShoppingCart(this);
        }
        public Customer(int id, string name) : base(id, name)
        {
            Cart = new ShoppingCart(this); // Tight Coupling -> Customer class is tightly coupled to the ShoppingCart class
        }
        public Customer(int id, string name, ShoppingCart cart) : base(id, name)
        {
            Cart = cart; // Loose Coupling -> Customer class is loose coupled to the ShoppingCart class
        }

        public Order PlaceOrder()
        {
            Order order = new Order(this, Cart.products);
            return order;
        }

        public void AddToCart(Product product)
        {
            Log.Information("Add product to the cart");
            Cart.AddProduct(product);
        }

        public void RemoveFromCart(Product product)
        {
            Log.Information("Remove product to the cart");
            Cart.RemoveProduct(product);
        }
    }
}
