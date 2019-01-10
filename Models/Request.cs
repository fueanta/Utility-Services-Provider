using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum RequestStatus { Pending = 1, Assigned = 2 }
    public class Request : Entity
    {
        [ForeignKey("UserId")]
        public virtual User User { get; set; } // User
        [Display(Name = "Consumer")]
        public int? UserId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        [Display(Name = "Service")]
        public int? ServiceId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss}")]
        [Display(Name = "Service Date and Time")]
        public DateTime ServiceDateTime { get; set; }

        [Required]
        public RequestStatus RequestStatus { get; set; }
    }
}
