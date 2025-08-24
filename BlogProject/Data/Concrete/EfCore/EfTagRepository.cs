using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;

namespace BlogProject.Data.Concrete;

public class EfTagRepository : ITagRepository
{
    private BlogContext _context;

    public EfTagRepository(BlogContext context)
    {
        _context = context;
    }
    public IQueryable<Tag> Tags => _context.Tags;

    public void CreatePost(Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
    }

}