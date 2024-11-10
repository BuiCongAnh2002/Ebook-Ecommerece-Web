using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BlogController : Controller
{
    OrganicContext context;

    public BlogController(OrganicContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        ViewBag.Departments = context.Departments.ToList();
        ViewBag.Categories = context.Categories.ToList();

        // Nếu có dữ liệu Blog trong cơ sở dữ liệu, bạn có thể lấy dữ liệu này từ context, ví dụ:
        // return View(context.Blogs.ToList());

        return View(); // Hiển thị trang blog mà không cần truyền thêm model nếu không có dữ liệu cụ thể
    }
}
