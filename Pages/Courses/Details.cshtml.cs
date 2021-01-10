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
    public class DetailsModel : PageModel
    {
        private readonly Matei_Proiect.Data.Matei_ProiectContext _context;

        public DetailsModel(Matei_Proiect.Data.Matei_ProiectContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course.FirstOrDefaultAsync(m => m.ID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
