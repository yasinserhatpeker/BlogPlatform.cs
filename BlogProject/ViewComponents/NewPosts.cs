using BlogProject.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents
{
    public class NewPosts : ViewComponent
    {
        private IPostRepository _postRepository;

        public NewPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_postRepository.Posts.ToList());
        }
    }
}