﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDemo07122019.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string   Name { get; set; }
        
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
