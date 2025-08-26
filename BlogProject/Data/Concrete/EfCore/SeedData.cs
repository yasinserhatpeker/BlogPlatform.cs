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
                    new Entity.Tag { TagText = "Football",TagUrl="football", TagColor=TagColors.primary},
                    new Entity.Tag { TagText = "Basketball" ,TagUrl="basketball",TagColor=TagColors.secondary },
                    new Entity.Tag { TagText = "Tennis", TagUrl="tennis",TagColor=TagColors.danger},
                    new Entity.Tag { TagText = "Volleyball", TagUrl="volleyball",TagColor=TagColors.info },
                    new Entity.Tag { TagText = "Formula 1", TagUrl="formula-1",TagColor=TagColors.succes }


                );
                context.SaveChanges();
            }

              if (!context.Users.Any())
            {
                context.Users.AddRange(
                  new User {UserName="yasinpeker" , UserImage="people1.jpg", Name ="Yasin Peker", Email="yasininfo@gmail.com", Password="1234"},
                  new User {UserName="ahmetergenc", UserImage="people2.jpeg", Name ="Ahmet Ergenç", Email="ahmetinfo@gmail.com", Password="1234"},
                  new User {UserName="tuanakormaz", UserImage="peoplew2.jpeg", Name ="Tuana Korkmaz", Email="tuanainfo@gmail.com", Password="1234"},
                  new User {UserName="yarenyilmaz", UserImage="peoplew2.jpg", Name ="Yaren Yılmaz", Email="yareninfo@gmail.com", Password="1234"}

                );
                context.SaveChanges();
            }
            
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        PostTitle = "Lebron James",
                        PostContet = "LeBron James is set to begin his 23rd season in the NBA, a milestone that highlights not only his longevity but also his ability to perform at an elite level across decades. No other player in league history has combined durability, consistency, and dominance quite like him, making this season another historic chapter in his legendary career.",
                        PostExp="LeBron James is set to begin his unprecedented 23rd NBA season, a milestone that cements his place as one of the greatest athletes in the history of sports. Since entering the league in 2003 as the number one overall pick, LeBron has carried expectations that few could meet, yet he has not only lived up to them but consistently surpassed them. Over the past two decades, he has become the NBA’s all-time leading scorer, captured multiple championships, earned MVP awards, and secured more than 20 All-Star appearances, all while remaining a dominant force well into his late 30s. What makes his 23rd season so extraordinary is not just the passage of time but the fact that he continues to play at an elite level when most players of his generation have long since retired. His commitment to conditioning, advanced recovery techniques, and an unwavering dedication to the game have allowed him to extend his career in ways that redefine longevity in professional basketball. LeBron’s influence, however, stretches far beyond the hardwood—through his business ventures, cultural presence, and philanthropy, including the groundbreaking I PROMISE School, he has set a new standard for what it means to be a modern athlete. Every game he plays now adds another layer to a legacy that will be studied and celebrated for generations, reminding fans around the world that they are witnessing history in real time. Season 23 is not just about chasing more records or adding to his highlight reel—it is about proving that greatness, resilience, and leadership can transcend time, making LeBron James an icon whose impact goes far beyond basketball.",
                        PostPublishedOn = DateTime.Now.AddDays(-10),
                        isActive = true,
                        PostUrl = "lebron-james",
                        PostImage = "lebron2.jpg",
                        Tags = context.Tags.Take(1).ToList(),
                        UserId = 1,
                        Comments=new List<Comment> {
                        new Comment { CommentText = "He is the GOAT!", CommentPublishedOn=DateTime.Now,UserId=1},
                        new Comment { CommentText = "Yeah he is great but Jordan is better btw", CommentPublishedOn= DateTime.Now, UserId=2}}

                    },
                      new Post
                      {
                          PostTitle = "Jannik Sinner",
                          PostContet = "Jannik Sinner has etched his name into tennis history by winning his first Wimbledon title, a triumph that signals the arrival of a new superstar on the sport’s biggest stage. At just 23 years old, the Italian sensation showcased his explosive groundstrokes, flawless movement, and remarkable mental strength to secure the most prestigious trophy in tennis.",
                          PostExp="Jannik Sinner has etched his name into tennis history by winning his first Wimbledon title, a triumph that signals the arrival of a new superstar on the sport’s biggest stage. At just 23 years old, the Italian sensation showcased his explosive groundstrokes, flawless movement, and remarkable mental strength to secure the most prestigious trophy in tennis, proving that his rise through the ranks was no accident. Sinner’s journey to his maiden Grand Slam victory has been marked by steady improvement, from his early days as a teenage prodigy to becoming one of the most consistent performers on tour, and his Wimbledon win now validates years of hard work, discipline, and dedication. Known for his powerful baseline game and ability to adapt under pressure, Sinner displayed maturity beyond his years throughout the tournament, taking down seasoned opponents and handling the spotlight with calm confidence. His victory not only marks a career-defining moment but also signals a generational shift in men’s tennis, as a new champion emerges to carry the sport forward in the post-Big Three era. For Italy, his triumph is a historic achievement, making him the first Italian man to win Wimbledon and inspiring a new wave of fans and future players. This championship run is more than just a personal milestone—it is a defining moment in tennis history, announcing Jannik Sinner as a true force to be reckoned with on the grandest stages of the game.",
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
                          PostContet = "Galatasaray have cemented their dominance in Turkish football by becoming back-to-back Süper Lig champions, a remarkable achievement that highlights their consistency, strength, and winning mentality. After a highly competitive season filled with dramatic matches and fierce rivalries.",
                          PostExp="Galatasaray have cemented their dominance in Turkish football by becoming back-to-back Süper Lig champions, a remarkable achievement that highlights their consistency, strength, and winning mentality. After a highly competitive season filled with dramatic matches and fierce rivalries, the Lions once again proved why they are the most decorated club in Turkey, adding another league title to their illustrious history. Led by a talented squad and guided by strong leadership on and off the pitch, Galatasaray combined experience, tactical discipline, and attacking flair to overcome every challenge that stood in their way. This consecutive triumph not only reinforces their reputation as the powerhouse of Turkish football but also secures their place in next season’s UEFA competitions, giving them another chance to showcase their quality on the European stage. For their passionate fanbase, known for creating one of the most electrifying atmospheres in world football, back-to-back championships represent more than silverware—they symbolize pride, tradition, and the continuation of a legacy built on resilience and glory. Galatasaray’s latest title run is a clear statement that they remain at the pinnacle of Turkish football, and with momentum on their side, the Lions look set to chase even greater success in the seasons to come.",
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
                          PostContet = "Liverpool have been crowned Premier League champions, a historic moment that marks the club’s return to the very top of English football after years of persistence, resilience, and rebuilding. With a season defined by consistency, tactical brilliance, and attacking power.",
                          PostExp="Liverpool have been crowned Premier League champions, a historic moment that marks the club’s return to the very top of English football after years of persistence, resilience, and rebuilding. With a season defined by consistency, tactical brilliance, and attacking power, Jürgen Klopp’s side delivered a brand of football that combined intensity, creativity, and discipline, proving too strong for their rivals across the campaign. Inspired by world-class talents such as Mohamed Salah, Virgil van Dijk, Trent Alexander-Arnold, and Alisson Becker, Liverpool dominated both at Anfield and away from home, breaking records and showcasing a mentality that reflects the club’s rich legacy. This triumph is not just another league title—it represents the culmination of a journey that restored Liverpool’s status as one of the elite forces in world football, delighting millions of fans across the globe who have passionately supported the Reds through every high and low. For supporters, the Premier League crown symbolizes more than just silverware; it embodies years of belief, unforgettable nights at Anfield, and the pride of seeing their club finally back at the pinnacle of English football. Liverpool’s championship victory is a statement that the Reds are not only back on top but are ready to continue competing for glory in England and Europe, cementing their place in football history.",
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
                          PostContet = "Paris Saint-Germain made an emphatic statement on the biggest stage by demolishing Inter Milan 5-0 in the UEFA Champions League final, a victory that showcased the club’s attacking brilliance, tactical mastery, and dominance in European football.",
                          PostExp="Paris Saint-Germain made an emphatic statement on the biggest stage by demolishing Inter Milan 5-0 in the UEFA Champions League final, a victory that showcased the club’s attacking brilliance, tactical mastery, and dominance in European football. From the first whistle, PSG controlled the match with fluid passing, relentless pressure, and clinical finishing, leaving Inter struggling to respond to the French giants’ intensity. The performance was a testament to the skill and cohesion of PSG’s star-studded squad, featuring world-class talents who combined speed, creativity, and composure under pressure to deliver one of the most memorable finals in recent Champions League history. This historic win not only secured PSG their long-sought European glory but also solidified their reputation as one of the most formidable teams on the continent, capable of breathtaking attacking displays and defensive solidity. For fans, the 5-0 triumph was a moment of sheer joy and pride, highlighting PSG’s journey from domestic dominance to continental supremacy. Beyond the scoreboard, the match demonstrated the tactical genius of the coaching staff and the resilience of a team that has consistently evolved to challenge Europe’s elite. PSG’s stunning victory over Inter Milan will be remembered as a defining moment in the club’s history, signaling that they are not just contenders but champions who can dominate on the grandest stage of them all.",
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
                          PostContet = "The Oklahoma City Thunder have captured a thrilling NBA Finals title, defeating the Indiana Pacers 4-3 in a hard-fought series that showcased the intensity, skill, and resilience of both teams. In a series defined by clutch performances, strategic adjustments, and unforgettable moments.",
                          PostExp="The Oklahoma City Thunder have captured a thrilling NBA Finals title, defeating the Indiana Pacers 4-3 in a hard-fought series that showcased the intensity, skill, and resilience of both teams. In a series defined by clutch performances, strategic adjustments, and unforgettable moments, OKC emerged victorious through a combination of explosive scoring, stifling defense, and leadership from their star players. The final Game 7 was a testament to the team’s composure under pressure, with key contributions from veterans and rising stars alike propelling the Thunder past a determined Pacers squad. This championship victory not only adds a new chapter to OKC’s history but also highlights the team’s ability to rise to the occasion when it matters most, proving their mettle on basketball’s biggest stage. For fans, the triumph is a moment of pure exhilaration, reflecting years of dedication, perseverance, and belief in the team’s potential. Beyond the trophy, the series win solidifies the Thunder as a force in the NBA, setting the stage for continued success and creating memories that will resonate with players and supporters for years to come.",
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