using Application.DTO;
using Application.IRepositorys;
using Domain;

namespace Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Create(CategoryDTO category)
        {
            return _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
            return;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByName(string name)
        {
            return _categoryRepository.GetByName(name);
        }

        public Category Update(CategoryDTO categoryDTO, int id)
        {
            return _categoryRepository.Update(categoryDTO, id);
        }
    }
}
