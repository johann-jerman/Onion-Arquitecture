using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositorys
{
    public interface ICategoryRepository
    {
        public Category GetById(int id);

        public Category GetByName(string name);
  
        public List<Category> GetAll();
        
        public Category Create(CategoryDTO Category);

        public Category Update(CategoryDTO Category, int id);

        public void Delete(int id);
    }
}
