using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postRepository;
    private ITagRepository _tagRepository;

    public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
        ;
    }
    public IActionResult Index()
    {
        return View(_postRepository.Posts.ToList());
    }
}