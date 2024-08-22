using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.PaymentMethods
{
    internal class PayPalPayment : PaymentMethod
    {
        override
        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Payment Process is PayPal : " + amount);
        }
    }
}
