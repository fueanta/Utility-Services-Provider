using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class EmployeeInfo : Entity
    {
        [Required]
        public double Salary { get; set; }

        [Required]
        [Range(100, 5000)]
        public double Commission { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; } // Employee
        [Display(Name = "Employee")]
        public int? UserId { get; set; }
    }
}
