using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;

namespace BlogProject.Data.Concrete;

public class EfPostRepository : IPostRepository
{
    private BlogContext _context;

    public EfPostRepository(BlogContext context)
    {
        _context = context;
    }
    public IQueryable<Post> Posts => _context.Posts;

    public void CreatePost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public void EditPost(Post post)
    {
        var entity = _context.Posts.FirstOrDefault(p => p.PostId == post.PostId);
        if (entity != null)
        {
            entity.PostTitle = post.PostTitle;
            entity.PostContet = post.PostContet;
            entity.PostExp = post.PostExp;
            entity.PostUrl = post.PostUrl;
            entity.isActive = post.isActive;

            _context.SaveChanges();

        }
    }

}