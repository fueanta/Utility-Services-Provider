using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum Gender { Male, Female, Other };
    public class ParentUser : Entity
    {
        // Id from Entity
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
    }
}
