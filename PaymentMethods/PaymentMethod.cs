using Business_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.PaymentMethods
{
    public abstract class PaymentMethod : IPayment
    {
        public abstract void ProcessPayment(double amount);
    }
}
