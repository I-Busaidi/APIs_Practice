using API_Practice1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practice1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Books).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Include(c => c.Books).FirstOrDefault(c => c.CatId == id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category NewCategory)
        {
            var currentCategory = GetById(id);
            if (currentCategory != null)
            {
                currentCategory.CatName = NewCategory.CatName;
                currentCategory.NumOfBooks = NewCategory.NumOfBooks;

                _context.Categories.Update(currentCategory);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
