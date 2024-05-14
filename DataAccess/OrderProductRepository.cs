using Application.DTO;
using Application.IRepositorys;
using Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly Context _context;

        public OrderProductRepository(Context context)
        {
            _context = context;
        }

        public Order AddProduct(OrderProductDTO orderProduct)
        {
            Order order = _context.Orders
                    .Include(o => o.Product)
                    .Include(o=> o.User)
                    .FirstOrDefault(o => o.Id == orderProduct.OrderId)
                    ?? throw new KeyNotFoundException($"no existe orden con ID: {orderProduct.OrderId}");
            
            Product product = _context.Products.FirstOrDefault(p => p.Id == orderProduct.ProductId)
                ?? throw new KeyNotFoundException($"no existe producto con ID: {orderProduct.ProductId}");

            order.Product.Add(product);
            order.TotalAmount += product.Price;
            _context.SaveChanges();
            return order;
        }
        public void DeleteProduct(int orderid, int productid)
        {
            try
            {
                Order order = _context.Orders.FirstOrDefault(o => o.Id == orderid)
                ?? throw new KeyNotFoundException($"no existe orden con ID: {orderid}");

            Product product = _context.Products.FirstOrDefault(o => o.Id == productid)
                ?? throw new KeyNotFoundException($"no existe orden con ID: {productid}");
            Console.WriteLine(productid);
            Console.WriteLine(orderid);
            
            order.Product.Remove(product);
            order.TotalAmount -= product.Price;
            _context.SaveChanges();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}
