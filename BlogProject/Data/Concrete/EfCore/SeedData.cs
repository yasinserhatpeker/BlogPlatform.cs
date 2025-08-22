using BlogProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data.Concrete.EfCore;

public static class SeedData
{
    public static void FillTestData(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

        if (context != null)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new Entity.Tag { TagText = "Sports" },
                    new Entity.Tag { TagText = "Politics" },
                    new Entity.Tag { TagText = "News" }


                );
                context.SaveChanges();
            }

              if (!context.Users.Any())
            {
                context.Users.AddRange(
                  new User {UserName="Yasin Peker"},
                  new User {UserName="Helin Akyüz"},
                  new User {UserName="Tuana Korkmaz"},
                  new User {UserName="Yaren Yılmaz"}

                );
                context.SaveChanges();
            }
            
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        PostTitle = "Lebron James",
                        PostContet = "Lebron James is starting his 23rd season!",
                        PostPublishedOn = DateTime.Now.AddDays(-10),
                        isActive = true,
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1

                    },
                      new Post
                      {
                          PostTitle = "Jannik Sinner",
                          PostContet = "Jannik Sinner wins his first Wimbledon! ",
                          PostPublishedOn = DateTime.Now.AddDays(-20),
                          isActive = true,
                          Tags = context.Tags.Take(2).ToList(),
                          UserId = 2

                      },
                      new Post
                      {
                          PostTitle = "Vladimir Putin",
                          PostContet = "Putin holds a meeting with Trump in Kremlin Palace",
                          PostPublishedOn = DateTime.Now.AddDays(-30),
                          isActive = true,
                          Tags = context.Tags.Take(4).ToList(),
                          UserId = 3

                      }


                );
                context.SaveChanges();
            }
           
        }


        }
}