using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Matei_Proiect.Data;
using Matei_Proiect.Models;

namespace Matei_Proiect.Pages.Courses
{
    public class CreateModel : CourseCategoriesPageModel
    {
        private readonly Matei_Proiect.Data.Matei_ProiectContext _context;

        public CreateModel(Matei_Proiect.Data.Matei_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var course = new Course();
            course.CourseCategories = new List<CourseCategory>();
            PopulateAssignedCategoryData(_context, course);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCourse = new Course(); if (selectedCategories != null)
            {
                newCourse.CourseCategories = new List<CourseCategory>(); foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CourseCategory
                    {
                        CategoryID = int.Parse(cat)
                    }; newCourse.CourseCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Course>(
                newCourse, 
                "Course", 
                i => i.Title, i => i.Professor,
                i => i.Price, i => i.Publishingdate, i => i.PublisherID)) 
            { _context.Course.Add(newCourse); 
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index"); 
            }
            PopulateAssignedCategoryData(_context, newCourse); return Page();
        }
    }
}
