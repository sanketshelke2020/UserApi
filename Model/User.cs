using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserApi.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Number and special Characters Not Allowed")]
        public string Name { get; set; }
        [Required]
        //[Remote("CustomerAlreadyExists", "Customer", HttpMethod = "POST", ErrorMessage = "Email already exists")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        //[Remote("CustomerAlreadyExists", "Register", ErrorMessage = "EmailId already exists in database.")]
        public string Email { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password must Contain minimum eight characters, at least one letter, one number and one special character")]
        public Byte[] PasswordHash { get; set; }
        public Byte[] PasswordSalt { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Must be at least 4 characters long.")]
        public string Address { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Number and special Characters Not Allowed")]
        public string Role { get; set; } = "user";
    }
}
