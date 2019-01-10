using Models;
using System.Collections.Generic;

namespace ViewModels
{
    public class UserFormViewModel
    {
        public User User { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Area> Areas { get; set; }
    }
}
