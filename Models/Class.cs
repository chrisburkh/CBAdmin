using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Models
{
    public class Class
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Course Course { get; set; }
        [Required]
        public Teacher Teacher { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
