using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CategoryName).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int CategoryId, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId.Equals(CategoryId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
