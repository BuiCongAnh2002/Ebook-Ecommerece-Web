using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    OrganicContext context;

    public ContactController(OrganicContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        ViewBag.Departments = context.Departments.ToList();
        ViewBag.Categories = context.Categories.ToList();

        return View(); // Hiển thị trang liên hệ
    }
}
