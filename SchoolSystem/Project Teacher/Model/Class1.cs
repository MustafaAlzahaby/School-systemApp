using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Teacher.Model
{
    public class Teacher
    {
        public int? ID { get; set; } = null;
        public string Name { get; set; }
        public int? Age { get; set; } = null;
        public int? Salary { get; set; }
        public string Subject { get; set; }
        public string Image { get; set; } 

        public override string ToString()
        {
            return Name;
        }
    }
}
