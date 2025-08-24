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
                    new Entity.Tag { TagText = "Football",TagUrl="football" },
                    new Entity.Tag { TagText = "Basketball" ,TagUrl="basketball" },
                    new Entity.Tag { TagText = "Tennis", TagUrl="tennis" },
                    new Entity.Tag { TagText = "Volleyball", TagUrl="volleyball" },
                    new Entity.Tag { TagText = "Formula 1", TagUrl="formula-1" }


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
                        PostUrl="lebron-james",
                        PostImage ="lebron2.jpg",
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1

                    },
                      new Post
                      {
                          PostTitle = "Jannik Sinner",
                          PostContet = "Jannik Sinner wins his first Wimbledon! ",
                          PostPublishedOn = DateTime.Now.AddDays(-20),
                          isActive = true,
                          PostUrl="jannik-sinner",
                           PostImage ="jannikSinner.jpg",
                          Tags = context.Tags.Take(2).ToList(),
                          UserId = 2

                      },
                      new Post
                      {
                          PostTitle = "Galatasaray",
                          PostContet = "Galatasaray are back-to-back champions!",
                          PostPublishedOn = DateTime.Now.AddDays(-30),
                          isActive = true,
                          PostUrl="galatasaray",
                          PostImage ="gs2.jpg",
                          Tags = context.Tags.Take(4).ToList(),
                          UserId = 3

                      },
                        new Post
                      {
                          PostTitle = "Liverpool",
                          PostContet = "Liverpool crownded as a Premier League Champions!",
                          PostPublishedOn = DateTime.Now.AddDays(-40),
                          isActive = true,
                          PostUrl="liverpool",
                          PostImage ="liverpool.jpg",
                          Tags = context.Tags.Take(4).ToList(),
                          UserId = 1

                      },
                        new Post
                      {
                          PostTitle = "Paris-Saint Germain",
                          PostContet = "PSG smashes Inter 5-0 in the Champions League final",
                          PostPublishedOn = DateTime.Now.AddDays(-50),
                          isActive = true,
                          PostUrl="psg-inter",
                          PostImage ="psg2.jpeg",
                          Tags = context.Tags.Take(4).ToList(),
                          UserId = 2

                      },
                        new Post
                      {
                          PostTitle = "NBA Finals",
                          PostContet = "OKC wins the Finals agains Pacers 4-3",
                          PostPublishedOn = DateTime.Now.AddDays(-60),
                          isActive = true,
                          PostUrl="okc-pacers",
                          PostImage ="okc2.jpeg",
                          Tags = context.Tags.Take(4).ToList(),
                          UserId = 3

                      }


                );
                context.SaveChanges();
            }
           
        }


        }
}