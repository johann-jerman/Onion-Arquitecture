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
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public Order Create(OrderDTO order)
        {
            Order newOrder = new () 
            {
                Name = order.Name,
                TotalAmount = order.TotalAmount,
                UserId = order.UserId,
            };
            _context.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public void Delete(int id)
        {
            Order order = _context.Orders
                .SingleOrDefault(o => o.Id == id)
                    ?? throw new KeyNotFoundException("no existe orden con ese id");
            order.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return;
        }

        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .Include(o => o.Product)
                .Include(o => o.User)
                .SingleOrDefault(o => o.Id == id)
                    ?? throw new KeyNotFoundException("no existe orden con ese id");
        }

        public Order Update(OrderDTO order, int id)
        {
            Order newOrder = _context.Orders.SingleOrDefault(o => o.Id == id)
                ?? throw new KeyNotFoundException("no existe orden con ese id");
            newOrder.Name = order.Name;
            newOrder.TotalAmount = order.TotalAmount;
            newOrder.UserId = order.UserId;
            _context.SaveChanges();
            return newOrder;
        }
    }
}
