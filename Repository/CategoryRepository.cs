using Contracts;
using Entities;
using Entities.Models;
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

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(c => c.CategoryName).ToList();
        }

        public Category GetCategory(int CategoryId, bool trackChanges)
        {
            return FindByCondition(c => c.CategoryId.Equals(CategoryId), trackChanges).SingleOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
