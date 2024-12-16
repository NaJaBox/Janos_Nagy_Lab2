using Janos_Nagy_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Janos_Nagy_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Janos_Nagy_Lab2.Data.Janos_Nagy_Lab2Context _context;

        public IndexModel(Janos_Nagy_Lab2.Data.Janos_Nagy_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = new List<Category>();
        public IList<Book> Books { get; set; } = new List<Book>();
        public int SelectedCategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            // Load categories
            Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                .ToListAsync() ?? new List<Category>();

            // Check for selected category
            if (id != null)
            {
                SelectedCategoryID = id.Value;

                // Find books in the selected category
                var selectedCategory = Categories.FirstOrDefault(c => c.ID == id.Value);
                if (selectedCategory != null && selectedCategory.BookCategories != null)
                {
                    Books = selectedCategory.BookCategories.Select(bc => bc.Book).ToList();
                }
            }
        }
    }
}
