using System;
using System.Collections.Generic;
using ProductInfrastructure.Model;

namespace ProductInfrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsEntities db = new ProductsEntities();

        public void Add(Category c)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category c)
        {
            throw new NotImplementedException();
        }

        public Category FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
