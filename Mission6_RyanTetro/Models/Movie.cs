using Mission06_RyanTetro.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_RyanTetro.Models
{

    public class Movie
    {
        [Key] // Data annotation to specify that MovieId is the primary key
        [Required] // Specifies that MovieId is a required field
        public int MovieId { get; set; } // Unique identifier for each movie

        [ForeignKey("CategoryID")] // Specifies that CategoryID is a foreign key
        [Required(ErrorMessage = "Category is required")] // Specifies that CategoryID is a required field with a custom error message
        public int? CategoryID { get; set; } // Nullable integer to store the associated Category's ID
        public Category? Category { get; set; } // Navigation property to the Category entity

        [Required(ErrorMessage = "Please input a Title")] // Specifies that Title is a required field with a custom error message
        public string Title { get; set; } // Stores the title of the movie

        [Range(1888, 2024, ErrorMessage = "Please input a valid year (1888-2024)")] // Specifies the valid range for Year with a custom error message
        public int Year { get; set; } = 0; // Stores the release year of the movie, initialized to 0 by default

        public string? Director { get; set; } // Nullable string to store the director's name

        public string? Rating { get; set; } // Nullable string to store the movie's rating (e.g., G, PG, PG-13, R)

        [Required(ErrorMessage = "Edited is required")] // Specifies that Edited is a required field with a custom error message
        public bool Edited { get; set; } // Boolean to indicate whether the movie has been edited

        public string? LentTo { get; set; } // Nullable string to store the name of the person the movie was lent to

        [Required(ErrorMessage = "Copied to Plex is required")] // Specifies that CopiedToPlex is a required field with a custom error message
        public bool CopiedToPlex { get; set; } // Boolean to indicate whether the movie has been copied to Plex

        [MaxLength(25, ErrorMessage = "Notes must be under 25 characters")] // Specifies the maximum length for Notes with a custom error message
        public string? Notes { get; set; } // Nullable string to store any additional notes about the movie (limited to 25 characters)
    }
}
