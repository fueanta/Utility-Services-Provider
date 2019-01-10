using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Service : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        [Display(Name = "Job Duration")]
        public double? ProbableDurationInHours { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Consumer Charge")]
        public double? ConsumerCharge { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Labour Charge")]
        public double? LabourCharge { get; set; }
    }
}
