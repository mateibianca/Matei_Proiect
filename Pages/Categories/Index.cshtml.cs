using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Proiect.Data;
using Matei_Proiect.Models;

namespace Matei_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Proiect.Data.Matei_ProiectContext _context;

        public IndexModel(Matei_Proiect.Data.Matei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
