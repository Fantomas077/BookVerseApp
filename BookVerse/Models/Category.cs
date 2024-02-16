using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookVerse.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is Required.")]
        [MaxLength(30, ErrorMessage = "maxlength is 30")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Name field is Required.")]
        [Range(1, 100, ErrorMessage = "Display Oder muss beetween 1-100 ")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
