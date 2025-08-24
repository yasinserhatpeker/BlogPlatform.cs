using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete;
using BlogProject.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
   
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();


var app = builder.Build();
app.UseStaticFiles();   
SeedData.FillTestData(app);

app.MapControllerRoute(
  name:"post_details",
  pattern:"posts/{url}",
  defaults: new { controller = "Posts", action="Details"}
);



app.MapControllerRoute(
   name:"default",
   pattern:"{controller=Posts}/{action=Index}/{id?}"
);

app.Run();
