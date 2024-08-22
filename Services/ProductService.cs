using Data_Layer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.DataModel;
using Serilog;

namespace Business_Layer.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public List<Product> GetAllProducts(string filename)
        {
            Log.Information("Get all products from Json  file");
            return _repository.GetAllProducts(filename);
        }

    }
}
