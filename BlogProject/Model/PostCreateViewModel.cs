using System.ComponentModel.DataAnnotations;
using BlogProject.Entity;

namespace BlogProject.Models
{
    public class PostCreateViewModel
    {
        [Required]
        
        [Display(Name = "Title")]
        public string? PostTitle { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string? PostContet { get; set; }

        [Required]
        public string? PostUrl { get; set; }

        [Required]
        public string? PostExp { get; set; }



        
    }
 }