using BlogProject.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.ViewComponents
{
    public class NewPosts : ViewComponent
    {
        private IPostRepository _postRepository;

        public NewPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            return View( await _postRepository.
            Posts.
            OrderByDescending(p=>p.PostPublishedOn).
            ToListAsync());
        }
    }
}