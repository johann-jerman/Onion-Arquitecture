using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IOrderProductService
    {
        public Order AddProduct(OrderProductDTO product);

        public void DeleteProduct(int orderid, int productid);
    }
}
