﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Janos_Nagy_Lab2.Data;
using Janos_Nagy_Lab2.Models;

namespace Janos_Nagy_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Janos_Nagy_Lab2.Data.Janos_Nagy_Lab2Context _context;

        public DetailsModel(Janos_Nagy_Lab2.Data.Janos_Nagy_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .ThenInclude(book => book.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
