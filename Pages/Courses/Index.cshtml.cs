using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Proiect.Data;
using Matei_Proiect.Models;

namespace Matei_Proiect.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Proiect.Data.Matei_ProiectContext _context;

        public IndexModel(Matei_Proiect.Data.Matei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get; set; }
        public CourseData CourseD { get; set; }
        public int CourseID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CourseD = new CourseData();

            CourseD.Courses = await _context.Course
            .Include(b => b.Publisher)
            .Include(b => b.CourseCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                CourseID = id.Value;
                Course course = CourseD.Courses
                .Where(i => i.ID == id.Value).Single();
                CourseD.Categories = course.CourseCategories.Select(s => s.Category);
            }
        }
    }
}
