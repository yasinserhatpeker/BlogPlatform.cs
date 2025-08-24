using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postRepository;
    
    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
       
        
    }
    public IActionResult Index()
    {
        return View(new PostViewModel
        {
            Posts = _postRepository.Posts.ToList(),
           
        });
    }
}