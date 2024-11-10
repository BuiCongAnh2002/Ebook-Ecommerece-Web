using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Linq;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        OrganicContext context;
        
        public HomeController(OrganicContext context)
        {
            this.context = context;
        }
        
        public IActionResult Index()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Categories = context.Categories.ToList();
            return View(context.Products.ToList());
        }
        
        public IActionResult Details(int id)
        {
            Product? product = context.Products.Find(id);
            if(product is null)
            {
                return Redirect("/");
            }
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.ProductsRelation = context.Products.Where(p => p.CategoryId == product.CategoryId && p.ProductId != id);
            return View(product);
        }

        public IActionResult Search(string keyword)
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Keyword = keyword;


            var results = context.Products
                                .Where(p => p.ProductName.Contains(keyword))
                                .ToList();

            
            if (results.Count == 1)
            {
                return RedirectToAction("Details", new { id = results[0].ProductId });
            }

            
            return View("SearchResults", results);
        }
    }
}
