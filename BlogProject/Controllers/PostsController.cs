using System.Security.Claims;
using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;
using BlogProject.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(PostCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _postRepository.CreatePost(new Post
                {
                    PostTitle = model.PostTitle,
                    PostContet = model.PostContet,
                    PostExp = model.PostExp,
                    PostUrl = model.PostUrl,
                    UserId = int.Parse(userId ?? ""),
                    PostImage = "liverpool.jpg",
                    isActive = false

                });
                return RedirectToAction("Index");

            }
            return View(model);

        }
        [Authorize
        ]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var posts = _postRepository.Posts;
            if (string.IsNullOrEmpty(role))
            {
                posts = posts.Where(x => x.UserId == userId);
            }

            return View(await posts.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("Error");
            }
            var post = _postRepository.Posts.FirstOrDefault(x => x.PostId == id);
            if (post == null)
            {
                return NotFound("Error");
            }

            return View(new PostCreateViewModel
            {
                PostId = post.PostId,
                PostContet = post.PostContet,
                PostExp = post.PostExp,
                PostUrl = post.PostUrl,
                PostTitle = post.PostTitle,
                isActive = post.isActive,

            });
        }
  }
   }