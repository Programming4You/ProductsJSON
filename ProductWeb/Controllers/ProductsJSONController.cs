using ProductWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace ProductWeb.Controllers
{
    public class ProductsJSONController : Controller
    {
        // GET: ProductsJSON
        public ActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            products = JsonConvert.DeserializeObject<List<ProductViewModel>>(readWrite.Read("products.json", "data"));

            return View(products);
        }


        // GET: Products/Create
        public ActionResult AddUpdate()
        {
            List<ProductViewModel> model = new List<ProductViewModel>();

            return View(model);
        }


        [HttpPost]
        public ActionResult AddUpdate(ProductViewModel productVM)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            products = JsonConvert.DeserializeObject<List<ProductViewModel>>(readWrite.Read("products.json", "data"));

            ProductViewModel product = products.FirstOrDefault(x => x.ProductID == productVM.ProductID);

            if (product == null)
            {
                products.Add(productVM);
            }
            else
            {
                int index = products.FindIndex(x => x.ProductID == productVM.ProductID);
                products[index] = productVM;
            }

            string jSONString = JsonConvert.SerializeObject(products);
            readWrite.Write("products.json", "data", jSONString);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    List<ProductViewModel> products = new List<ProductViewModel>();
        //    JSONReadWrite readWrite = new JSONReadWrite();
        //    products = JsonConvert.DeserializeObject<List<ProductViewModel>>(readWrite.Read("products.json", "data"));

        //    int index = products.FindIndex(x => x.ProductID == id);
        //    products.RemoveAt(index);

        //    string jSONString = JsonConvert.SerializeObject(products);
        //    readWrite.Write("products.json", "data", jSONString);

        //    return RedirectToAction("index", "Product");
        //}

    }
}