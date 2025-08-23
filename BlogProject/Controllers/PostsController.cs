using BlogProject.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

public class PostsController : Controller
{
    private readonly BlogContext _context;

    public PostsController(BlogContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Posts.ToList());
    }
}