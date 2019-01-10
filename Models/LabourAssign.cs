using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LabourAssign : Entity
    {
        [ForeignKey("UserId")]
        public virtual User User { get; set; } // Labour
        [Display(Name = "Labour")]
        public int? UserId { get; set; }

        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
        [Display(Name = "Request")]
        public int? RequestId { get; set; }
    }
}
