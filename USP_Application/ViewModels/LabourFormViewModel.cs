using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USP_Application.ViewModels
{
    public class LabourFormViewModel
    {
        public Labour Labour { get; set; }
        public UserLogin UserLogin { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Area> Areas { get; set; }
    }
}