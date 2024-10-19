using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Janos_Nagy_Lab2.Models;

namespace Janos_Nagy_Lab2.Data
{
    public class Janos_Nagy_Lab2Context : DbContext
    {
        public Janos_Nagy_Lab2Context (DbContextOptions<Janos_Nagy_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Janos_Nagy_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Janos_Nagy_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Janos_Nagy_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
