﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Models
{
    public class Student
    {

        [Key]
        public string Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType Gender { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
