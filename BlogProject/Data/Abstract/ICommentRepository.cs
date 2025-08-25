using BlogProject.Entity;

namespace BlogProject.Data.Abstract;

public interface ICommentRepository
{
    IQueryable<Comment> Comments { get; }
     
    void CreatePost(Comment comment); 
}
