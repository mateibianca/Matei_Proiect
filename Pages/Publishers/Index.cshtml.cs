using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Proiect.Data;
using Matei_Proiect.Models;

namespace Matei_Proiect.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Proiect.Data.Matei_ProiectContext _context;

        public IndexModel(Matei_Proiect.Data.Matei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
