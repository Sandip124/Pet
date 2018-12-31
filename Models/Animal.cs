using System.ComponentModel.DataAnnotations;

namespace Pet.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage="{0} must be greater  or equal  to {1} character in length.")]
        public string Name { get; set; }
        [Required]
        [Range(0,5,ErrorMessage="{0} must be between {1} and {2} years.")]
        public int Age { get; set; }
        [Required]
        public string Color { get; set; }
    }
}