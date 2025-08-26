using System.ComponentModel.DataAnnotations;
using BlogProject.Entity;

namespace BlogProject.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }
       
       [Required]
       [Display(Name = "Full Name")]
        public string? Name { get; set; }

        
    }
 }