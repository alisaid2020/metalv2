using finalMetalCore.Areas.Identity.Data;
using finalMetalCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace finalMetalCore.Controllers
{
    public class HomeController : Controller
    {
     
  

        #region dbobject
        finalMetalCoreContext db;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(finalMetalCoreContext db,
            IHostingEnvironment hostingEnvironment
            )
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;

        }
        #endregion


        #region index
        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region cash
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion


        #region about
        public IActionResult About()
        {
            return View();
        }
        #endregion


        #region contact
        [HttpGet]
        public IActionResult contact()
        {
            return View();
        }

        #endregion


        #region product admin
        public IActionResult productsAdmin()
        {
            var prods = db.Products.ToList();
            return View(prods);
        }
        #endregion


        #region product user
        public IActionResult products()
        {
            var prods = db.Products.ToList();
            return View(prods);
        }
        #endregion


        #region Add product
        [HttpGet]
        public IActionResult Addproduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addproduct(finalMetalCore.viewModels.productViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image1 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image1.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image1.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                string uniqueFileName1 = null;
                if (model.Image2 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.Image2.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                    model.Image2.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                string uniqueFileName2 = null;
                if (model.Image3 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Image3.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                    model.Image3.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                product newproduct = new product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Image1 = uniqueFileName,
                    Image2 = uniqueFileName1,
                    Image3 = uniqueFileName2

                };


                db.Add(newproduct);
                db.SaveChanges();
                return RedirectToAction("products");
            }
            return View();
        }
        #endregion


        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = db.Products.Find(id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(product prod)
        {
            db.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("products");
        }
        #endregion


        #region delet
        [HttpGet]
        public IActionResult Delet(int id)
        {

            var prod = db.Products.Find(id);
            db.Products.Remove(prod);
            db.SaveChanges();
            return RedirectToAction("products");
        }
        #endregion


        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var prod = db.Products.Find(id);
            return View(prod);
        }
        #endregion





    }
}
