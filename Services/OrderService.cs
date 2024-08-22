using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Interfaces;
using Data_Layer.DataModel;
using Serilog;
namespace Business_Layer.Services
{
    public class OrderService : IDiscountable
    {
        public void PlaceOrder(Customer customer,ShoppingCart cart)
        {
            Order order = new Order
            {
                Products = cart.products,
                Status = OrderStatus.Processing,
                OrderDate = DateTime.Now
            };
        }
        public double ApplyDiscount(Order order,double discount)
        {
            Log.Information("Apply discount");
            return order.CalculateOrder() - (order.CalculateOrder()*discount/100);
        }
    }
}
