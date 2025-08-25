using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;

namespace BlogProject.Data.Concrete;

public class EfCommentRepository : ICommentRepository
{
    private BlogContext _context;

    public EfCommentRepository(BlogContext context)
    {
        _context = context;
    }
    public IQueryable<Comment> Comments => _context.Comments;

    

    public void CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

  
}