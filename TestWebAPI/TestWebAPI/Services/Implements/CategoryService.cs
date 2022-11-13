using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private TestContext _context;

        public CategoryService(TestContext context)
        {
            _context = context;
        }

        public Category Add(AddCategoryRequest categoryToAdd)
        {
            var cat = new Category
            {
                CategoryName = categoryToAdd.CategoryName
            };
             _context.Categories.Add(cat);
             _context.SaveChanges();

            return cat;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<Category> GetAll()
        {
            var category =_context.Categories.Where(c => c.IsDeleted == false).ToList();

            return category;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(x => x.CategoryId == id);
            
            if(category == null)
            {
                return null;
            }

            return category;
        }

        public bool SoftDelete(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {
                category.IsDeleted = true;
                _context.Update(category);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public Category Update(int id, UpdateCategoryRequest catToUpdate)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId==id);

            if (category == null)
            {
                return null;
            }

            category.CategoryName = catToUpdate.CategoryName;

            _context.Categories.Update(category);
            _context.SaveChanges();

            return category;
        }
    }
}
