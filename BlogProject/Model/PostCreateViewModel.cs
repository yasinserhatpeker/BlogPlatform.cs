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
         [Display(Name = "Post Url")]
        public string? PostUrl { get; set; }
        [Required]
        [Display(Name = "Post Explanation")]
        public string? PostExp { get; set; }



        
    }
 }