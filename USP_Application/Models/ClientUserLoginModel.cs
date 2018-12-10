﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USP_Application.Models
{
    public class ClientUserLoginModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
    }
}