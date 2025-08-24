using BlogProject.Entity;

namespace BlogProject.Data.Abstract;

public interface ITagRepository
{
    IQueryable<Tag> Tags { get; }
     
    void CreatePost(Tag tags); 
}
