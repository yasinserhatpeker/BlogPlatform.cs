using System;
using System.Security.Cryptography.Xml;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BlogProject.Entity;

public class Post
{
    public int PostId { get; set; }

    public string? PostTitle { get; set; }

    public string? PostUrl { get; set; }

    public string? PostContet { get; set; }

    public string? PostImage { get; set; }

    public DateTime PostPublishedOn { get; set; }

    public bool isActive { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public List<Tag> Tags { get; set; } = new List<Tag>();

    public List<Comment> Comments { get; set; } = new List<Comment>();

    

}
