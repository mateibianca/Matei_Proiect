using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matei_Proiect.Models
{
    public class CourseData
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CourseCategory> CourseCategories { get; set; }
    }
}
