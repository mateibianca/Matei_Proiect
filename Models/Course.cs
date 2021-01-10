using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matei_Proiect.Models
{
    public class Course
    {
        
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Course")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Professor name has to contain last name and first name"), Required, StringLength(50, MinimumLength = 3)]
        public string Professor { get; set; }
        [Range(1, 500)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Publishingdate { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; }
    }
}
