using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Pet.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage="{0} must be greater  or equal  to {1} character in length.")]
        [Remote(action: "VerifyName", controller: "Animal")]
        public string Name { get; set; }
        [Required]
        [Range(1,5,ErrorMessage="{0} must be between {1} and {2} years.")]
        public int Age { get; set; }
        [Required]
        public string Color { get; set; }
    }
}