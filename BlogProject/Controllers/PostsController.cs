using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

public class PostsController : Controller
{
    private IPostRepository _repository;

    public PostsController(IPostRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
        return View(_repository.Posts.ToList());
    }
}