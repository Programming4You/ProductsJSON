using ProductInfrastructure.Interfaces;
using ProductInfrastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;



namespace ProductInfrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsEntities db = new ProductsEntities();

        public void Add(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public void Edit(Product p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Product FindById(int id)
        {
            var result = (from p in db.Products
                          join c in db.Categories on p.CategoryID equals c.CategoryID
                          where p.ProductID == id select p).FirstOrDefault();

            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
              return db.Products.Include(c => c.Category);
        }

        public void Remove(int id)
        {
            Product p = db.Products.Find(id);
            db.Products.Remove(p);
            db.SaveChanges();
        }
    }
}
