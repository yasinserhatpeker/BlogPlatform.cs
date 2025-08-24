using BlogProject.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents
{
    public class TagsMenu : ViewComponent
    {
        private ITagRepository _tagRepository;

        public TagsMenu(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_tagRepository.Tags.ToList());
        }
    }
}