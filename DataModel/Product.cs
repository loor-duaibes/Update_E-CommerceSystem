using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.DataModel
{
    public class Product
    {
        public int ProductID { set; get; }
        public string ProductName { set; get; }
        public double ProductPrice { set; get; }

        public Product() { }
        public Product(int id, string name, double price)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
        }

        public void GetProductInfo()
        {
            Console.WriteLine("ID : " + ProductID + " , Name : " + ProductName + " , Price : " + ProductPrice);
        }
        public void UpdatePrice(double price)
        {
            Log.Information("Update Price for {ProductID} from {ProductPrice} to {price}");
            ProductPrice = price;
        }
    }
}
