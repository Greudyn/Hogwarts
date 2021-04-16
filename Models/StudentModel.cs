using System.ComponentModel.DataAnnotations;

namespace Hogwarts.Models
{
    public class StudentModel
    {
        [Required]
        [StringLength(10)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "Age must between 1 to 99")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"(Gryffindor|Hufflepuff|Ravenclaw|Slytherin)", ErrorMessage = "Must be any of the house of Gryffindor,Hufflepuff,Ravenclaw or Slytherin.")]
        public string House { get; set; }
    }
}