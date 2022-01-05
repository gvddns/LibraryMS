﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories(bool trackChanges);
        public Category GetCategory(int CategoryId, bool trackChanges);
        void CreateCategory(Category category);
    }
}