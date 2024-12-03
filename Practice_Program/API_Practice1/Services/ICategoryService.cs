using API_Practice1.Models;

namespace API_Practice1.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        void RemoveCategory(int id);
        void UpdateCategory(int id, Category newCategory);
        void IncrementCategoryBookNumber(int id);
        void DecrementCategoryBookNumber(int id);
    }
}