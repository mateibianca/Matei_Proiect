using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matei_Proiect.Models
{
    public class CourseCategory
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
