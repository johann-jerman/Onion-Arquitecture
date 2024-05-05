using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositorys
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Create(ProductDTO product);
        Product Update(ProductDTO product, int id);
        void Delete(int id);
    }
}
