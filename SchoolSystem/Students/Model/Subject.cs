using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model
{
    public class Subject
    {
        public string SubName { get; set; }
        public string stud1 { get; set; } 
        public string stud2 { get; set; }
        public string stud3 { get; set; }
        public string stud4 { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return SubName;
        }
    }
}
