using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookVerse.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Title field is Required.")]
        [Display(Name = "Book Title")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Content field is Required.")]
        public string Content { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Posteddate { get; set; }

        [Required(ErrorMessage = "The Author field is Required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Author { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]

        public IFormFile ImageFile { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }


    }
}
