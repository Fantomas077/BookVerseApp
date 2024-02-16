using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookVerse.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is Required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Content field is Required.")]
        public string Content { get; set; }
        [Required]
        public DateTime Posteddate { get; set; }
        [Required(ErrorMessage = "The Author field is Required.")]
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
