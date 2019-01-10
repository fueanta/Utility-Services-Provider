using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum TransactionType { Recharge = 1, Withdraw = 2 }
    public class Transaction : Entity
    {
        [ForeignKey("UserId")]
        public virtual User User { get; set; } // Labour
        [Display(Name = "Labour")]
        public int? UserId { get; set; }

        [Required]
        [Range(500, 10000)]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss}")]
        [Display(Name = "Transaction Date and Time")]
        public DateTime TransactionDateTime { get; set; }
    }
}
