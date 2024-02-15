using System.ComponentModel.DataAnnotations;

namespace Mission6_RyanTetro.Models
{
    public class Submition
    {
        // Assuming 'Category' is a string type. Adjust types as necessary.
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        // Boolean type for Yes/No (True/False) selection
        public bool Edited { get; set; }

        // 'LentTo' and 'Notes' are optional, so no [Required] attribute
        public string LentTo { get; set; }

        [MaxLength(25)] // Ensures Notes does not exceed 25 characters
        public string Notes { get; set; }


    }
}
