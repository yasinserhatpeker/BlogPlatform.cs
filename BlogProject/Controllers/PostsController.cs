using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

public class PostsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}