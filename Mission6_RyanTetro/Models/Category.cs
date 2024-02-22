using System.ComponentModel.DataAnnotations;

namespace Mission06_RyanTetro.Models
{
    public class Category
    {

        // Data annotation to specify that CategoryId is the primary key
        [Key]
        public int CategoryId { get; set; }

        // Specifies that CategoryName is a required field with a custom error message
        [Required(ErrorMessage = "Category name is requried")]
        public string CategoryName { get; set; }
    }
}
