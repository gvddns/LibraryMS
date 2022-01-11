using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryAsync(int CategoryId);
        void CreateCategory(Category category);
        public void DeleteCategory(Category category);
        public void UpdateCategory(Category category);
    }
}
