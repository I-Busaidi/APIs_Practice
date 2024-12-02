using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Update(int id, Category NewCategory);
    }
}