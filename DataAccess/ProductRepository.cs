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
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context) { this._context = context; }

        public Product Create(ProductDTO product)
        {
            Product newProduct = new()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public void Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id)
                ?? throw new KeyNotFoundException("No existe elemento con esa clave");
            _context.Products.Remove(product);
            _context.SaveChanges();
            return;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id)
                ?? throw new KeyNotFoundException("No existe elemento con esa clave");
        }

        public Product Update(ProductDTO productDTO, int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id)
               ?? throw new KeyNotFoundException("No existe elemento con esa clave");
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.CategoryId= productDTO.CategoryId;
            product.Description= productDTO.Description;
            _context.SaveChanges();

            return product;
        }
    }
}
