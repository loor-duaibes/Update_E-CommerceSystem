using Business_Layer.Interfaces;
using Business_Layer.PaymentMethods;
using Data_Layer.DataModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class PaymentService : IPayment
    {
        private readonly PaymentMethod _paymentMethod;

        public PaymentService(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }
        public void ProcessPayment(double amount)
        {
            try
            {
                _paymentMethod.ProcessPayment(amount);
                Log.Information("Successful Payment");
                Console.WriteLine("Payment processed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Payment failed: {ex.Message}");

            }
        }
    }
}
