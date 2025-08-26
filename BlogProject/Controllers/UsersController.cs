using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EfCore;
using BlogProject.Entity;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        public IActionResult Login()
        {
            return View();
        }
    }

}