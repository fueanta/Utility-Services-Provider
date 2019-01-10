using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Area : Entity
    {
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [Display(Name = "City")]
        public int? CityId { get; set; }
    }
}
