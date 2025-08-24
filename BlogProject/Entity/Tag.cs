using System;

namespace BlogProject.Entity;

public enum TagColors
{
    primary,secondary,danger,info,warning,succes
}
public class Tag
{

    public int TagId { get; set; }

    public string? TagText { get; set; }

    public string? TagUrl { get; set; }

    public TagColors? TagColor { get; set; }



    public List<Post> Posts { get; set; } = new List<Post>();


}
