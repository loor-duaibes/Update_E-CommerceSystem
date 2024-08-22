using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataModel;

namespace Business_Layer.Interfaces
{
    public interface IDiscountable
    {
        double ApplyDiscount(Order order,double discount);

    }
}
