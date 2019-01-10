using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "Email or Phone")]
        public string EmailOrPhone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
