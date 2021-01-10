using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Matei_Proiect.Models;

namespace Matei_Proiect.Data
{
    public class Matei_ProiectContext : DbContext
    {
        public Matei_ProiectContext (DbContextOptions<Matei_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Matei_Proiect.Models.Course> Course { get; set; }

        public DbSet<Matei_Proiect.Models.Publisher> Publisher { get; set; }

        public DbSet<Matei_Proiect.Models.Category> Category { get; set; }
    }
}
