using Test.Data.Entities;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        Category Add(AddCategoryRequest categoryToAdd);

        Category Update(int id, UpdateCategoryRequest catToUpdate);

        Category GetById(int id);

        bool Delete(int id);

        bool SoftDelete(int id);
    }
}
