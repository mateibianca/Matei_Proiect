using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matei_Proiect.Data;
using Matei_Proiect.Models;


namespace Matei_Proiect.Pages.Courses
{
    public class EditModel : CourseCategoriesPageModel
    {
        private readonly Matei_Proiect.Data.Matei_ProiectContext _context;

        public EditModel(Matei_Proiect.Data.Matei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course
                .Include(b => b.Publisher)
                .Include(b => b.CourseCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Course == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Course);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)

        {
            if (id == null)
            {
                return NotFound();
            }
            var courseToUpdate = await _context.Course
            .Include(i => i.Publisher)
            .Include(i => i.CourseCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (courseToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Course>(courseToUpdate,"Course",
            i => i.Title, i => i.Professor,
            i => i.Price, i => i.Publishingdate, i => i.Publisher))
            {
                UpdateCourseCategories(_context, selectedCategories, courseToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCourseCategories(_context, selectedCategories, courseToUpdate);
            PopulateAssignedCategoryData(_context, courseToUpdate);
            return Page();
        }
    }  
}
