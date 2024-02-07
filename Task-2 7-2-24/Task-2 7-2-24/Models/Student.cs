using System.ComponentModel.DataAnnotations;

namespace Task_2_7_2_24.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s\.\-]+$", ErrorMessage = "Name must contain only alphabets, spaces, '.', or '-'")]
        public string Name { get; set; }


        [Required(ErrorMessage = "ID is required")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Invalid ID format")]

        public string ID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{1,10}$", ErrorMessage = "Username must be alphanumeric and maximum 10 characters")]
         public string Username { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}
