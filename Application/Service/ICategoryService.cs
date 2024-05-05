using Application.DTO;
using Domain;

namespace Application.Service
{
    public interface ICategoryService
    {
        public Category GetById(int id);

        public Category GetByName(string name);

        public List<Category> GetAll();

        public Category Create(CategoryDTO Category);

        public Category  Update(CategoryDTO Category, int id);

        public void Delete(int id);
    }
}
