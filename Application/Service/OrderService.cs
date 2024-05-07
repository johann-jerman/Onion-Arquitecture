using Application.DTO;
using Application.IRepositorys;
using Domain;

namespace Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public Order Create(OrderDTO order)
        {
            return _orderRepository.Create(order);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
            return;
        }

        public IEnumerable<Order> Get()
        {
            return _orderRepository.Get();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public Order Update(OrderDTO order, int id)
        {
            return _orderRepository.Update(order, id);
        }
    }
}