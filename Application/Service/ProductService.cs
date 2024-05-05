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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;            
        }

        public Product Create(ProductDTO product)
        {
            return this._productRepository.Create(product);
        }

        public void Delete(int id)
        {
            this._productRepository.Delete(id);
            return;
        }

        public IEnumerable<Product> GetAll()
        {
            return this._productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return this._productRepository.GetById(id);
        }

        public Product Update(ProductDTO product, int id)
        {
            return this._productRepository.Update(product, id);
        }
    }
}
