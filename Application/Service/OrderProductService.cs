using Application.DTO;
using Application.IRepositorys;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository orderProductRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            this.orderProductRepository = orderProductRepository;
        }

        public Order AddProduct(OrderProductDTO orderProduct)
        {
            return orderProductRepository.AddProduct(orderProduct);
        }

        public void DeleteProduct(int orderid , int productid)
        {
            orderProductRepository.DeleteProduct(orderid, productid);
            return;
        }
    }
}
