using Application.DTO;
using Application.IRepositorys;
using Application.Service;
using Configuration;
using Domain;

namespace DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            this._context = context;
        }


        public Category Create(CategoryDTO Category)
        {
            Category category = new()
            {
                Name = Category.Name,
            };
            _context.Categorys.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            Category category = _context.Categorys.SingleOrDefault(c => c.Id == id) 
                ?? throw new KeyNotFoundException("no existe el elemento a elminar");
            _context.Categorys.Remove(category);
            _context.SaveChanges();
            return;
        }

        public List<Category> GetAll()
        {
            return _context.Categorys.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categorys.SingleOrDefault(c => c.Id == id) 
                ?? throw new KeyNotFoundException("No existe elemento con ese id");
        }

        public Category GetByName(string name)
        {
            return _context.Categorys.Single(c => c.Name == name);
        }

        public Category Update(CategoryDTO categoryDTO, int id)
        {
            Category category = _context.Categorys.SingleOrDefault(x => x.Id == id) 
                ?? throw new KeyNotFoundException("no existe el elementeo a actualizar");
            category.Name = categoryDTO.Name;
            return category;
        }
    }
}
