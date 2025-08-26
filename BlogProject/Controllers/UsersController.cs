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

        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
           _userRepository=userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

                if (user != null)
                {

                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect.");
                }
            }
             return View(model);
        }
    }

}