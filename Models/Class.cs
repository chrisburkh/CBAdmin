using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Models
{
    public class Class
    {
        public String course { get; set; }

        public ICollection<Student> students { get; set; }

    }
}
