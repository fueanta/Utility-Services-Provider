using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LabourInfo : Entity
    {
        [Required]
        [Range(0, 25000)]
        public double Wallet { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; } // Labour
        [Display(Name = "Labour")]
        public int? UserId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        [Display(Name = "Service")]
        public int? ServiceId { get; set; }
    }
}
