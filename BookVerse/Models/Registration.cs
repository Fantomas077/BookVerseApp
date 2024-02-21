using System.ComponentModel.DataAnnotations;

namespace BookVerse.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is Required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Vorname field is Required.")]
        [Display(Name = "Vorname")]
        public string Vorname { get; set; }
        [Required(ErrorMessage = "The Email field is Required.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password field is Required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
