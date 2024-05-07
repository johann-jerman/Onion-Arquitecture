using Application.DTO;
using Domain;

namespace Application.Service
{
    public interface IOrderService
    {
        public IEnumerable<Order> Get();

        public Order GetById(int id);

        public Order Create(OrderDTO order);

        public Order Update(OrderDTO order, int id);

        public void Delete(int id);
    }
}
