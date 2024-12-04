using API_Practice1.Models;
using API_Practice1.Repositories;

namespace API_Practice1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll()
                .OrderBy(c => c.CatName)
                .ToList();
            if (categories == null || categories.Count == 0)
            {
                throw new InvalidOperationException("No categories found.");
            }
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var category = _categoryRepository.GetAll().FirstOrDefault(c => c.CatName == name);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            return category;
        }

        public void AddCategory(Category category)
        {
            if (category.CatName == null)
            {
                throw new ArgumentException("Category name is required.");
            }

            _categoryRepository.Add(category);
        }

        public void RemoveCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            if (category.NumOfBooks > 0)
            {
                throw new InvalidOperationException("Cannot delete categories with books in it.");
            }

            _categoryRepository.Delete(id);
        }

        public void UpdateCategory(int id, Category newCategory)
        {
            var existingCategory = _categoryRepository.GetById(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }

            newCategory.CatId = existingCategory.CatId;
            _categoryRepository.Update(newCategory.CatId, newCategory);
        }

        public void IncrementCategoryBookNumber(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }

            category.NumOfBooks++;
            _categoryRepository.Update(category.CatId, category);
        }
        public void DecrementCategoryBookNumber(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }

            category.NumOfBooks--;
            _categoryRepository.Update(category.CatId, category);
        }
    }
}
