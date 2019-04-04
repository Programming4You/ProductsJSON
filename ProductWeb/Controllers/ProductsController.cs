using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductInfrastructure;
using ProductInfrastructure.Model;
using ProductWeb.Models;

namespace ProductWeb.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductRepository _dbProducts = new ProductRepository();
        private readonly CategoryRepository _dbCategories = new CategoryRepository();


        // GET: Products
        public ActionResult Index()
        {
            var model = (from p in _dbProducts.GetProducts()
            select new ProductViewModel {
                             ProductID = p.ProductID,
                             Name = p.Name,
                             Description = p.Description,
                             CategoryID = p.CategoryID,
                             Producer = p.Producer,
                             Supplier = p.Supplier,
                             Price = p.Price,
                             CategoryName = p.Category.CategoryName
                         }).ToList();
            

            return View(model);
        }


        // GET: Products/Create
        public ActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();

            ViewBag.CategoryID = new SelectList(_dbCategories.GetCategories(), "CategoryID", "CategoryName");
            return View(model);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Description,CategoryID,Producer,Supplier,Price")] ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = productVM.Name,
                    Description = productVM.Description,
                    CategoryID = productVM.CategoryID,
                    Producer = productVM.Producer,
                    Supplier = productVM.Supplier,
                    Price = productVM.Price
                };

                _dbProducts.Add(product);

                return RedirectToAction("Index");
            }

            return View(productVM);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
             Product product = _dbProducts.FindById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            ProductViewModel productVM = new ProductViewModel();
            productVM.ProductID = product.ProductID;
            productVM.Name = product.Name;
            productVM.Description = product.Description;
            productVM.CategoryID = product.CategoryID;
            productVM.Producer = product.Producer;
            productVM.Supplier = product.Supplier;
            productVM.Price = product.Price;
 
            ViewBag.CategoryID = new SelectList(_dbCategories.GetCategories(), "CategoryID", "CategoryName", productVM.CategoryID);

            return View(productVM);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,CategoryID,Producer,Supplier,Price")] ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                Product p = _dbProducts.GetProducts().FirstOrDefault(x => x.ProductID == productVM.ProductID);

                p.ProductID = productVM.ProductID;
                p.Name = productVM.Name;
                p.Description = productVM.Description;
                p.CategoryID = productVM.CategoryID;
                p.Producer = productVM.Producer;
                p.Supplier = productVM.Supplier;
                p.Price = productVM.Price;

                _dbProducts.Edit(p);

                return RedirectToAction("Index");
            }
   
            return View(productVM);
        }

     
    }
}
