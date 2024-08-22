using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.PaymentMethods
{
    public class CreditCardPayment : PaymentMethod
    {
        override
        public void ProcessPayment(double amount)
        {
            double balance = 10000;
            if (amount > balance)
            {
                Console.WriteLine("Amount is not enough to purchase all these products");
            }
            else
            {
                Console.WriteLine("Payment Process is a CreditCard :" + amount);
            }

        }
    }
}
