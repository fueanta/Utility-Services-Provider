using Models.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum UserType { Admin = 1, Employee = 2, Consumer = 3, Labour = 4 }
    public enum Gender { Male = 1, Female = 2 }
    public class User : Entity
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }
        
        [DataType(DataType.Date)]
        [CustomValidationForBirthdate]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }
        [Display(Name = "Area")]
        public int AreaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss}")]
        [Display(Name = "Joining Date and Time")]
        public DateTime JoiningDateTime { get; set; }

        public string PhotoPath { get; set; }

        [DataType(DataType.Password)]
        [CustomValidationForPassword]
        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
