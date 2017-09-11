﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSampleGrid.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public List<Models.Order> Orders { get; set; }
    }
}