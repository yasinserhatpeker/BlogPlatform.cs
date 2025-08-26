using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{ 
    


public class PostsController : Controller
{
    private IPostRepository _postRepository;

    private ICommentRepository _commentRepository;

    public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        _postRepository = postRepository;
        _commentRepository = commentRepository;


    }
    public async Task<IActionResult> Index(string tag)
    {
            var claims = User.Claims;
        var posts = _postRepository.Posts;
        if (!string.IsNullOrEmpty(tag))
        {
            posts = posts.Where(x => x.Tags.Any(t => t.TagUrl == tag));
        }
        return View(new PostViewModel
        {
            Posts = await posts.ToListAsync()

        });
    }
    public async Task<IActionResult> Details(string url)
    {
        return View(await _postRepository.Posts.
        Include(x => x.Tags).
        Include(x => x.Comments).
        ThenInclude(x => x.User).
        FirstOrDefaultAsync(p => p.
        PostUrl == url));
    }


    public IActionResult AddComment(int PostId, string UserName, string CommentText, string Url)
    {
        var entity = new Comment
        {
            CommentText = CommentText,
            CommentPublishedOn = DateTime.Now,
            PostId = PostId,
            User = new User { UserName = UserName, UserImage = "people1.jpg" },
        };

        _commentRepository.CreateComment(entity);

        return RedirectToRoute("post_details", new { url = Url });
        }
  }
   }