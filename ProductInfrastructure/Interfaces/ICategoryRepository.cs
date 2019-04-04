using ProductInfrastructure.Model;
using System.Collections.Generic;


namespace ProductInfrastructure
{
    interface ICategoryRepository
    {
        void Add(Category c);
        void Edit(Category c);
        void Remove(int id);
        IEnumerable<Category> GetCategories();
        Category FindById(int id);
    }
}
