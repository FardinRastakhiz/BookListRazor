using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Book = await _dbContext.Book.FindAsync(id);
            if (Book == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            ModelState.AddModelError("Error", "Check ID2");

            var deletedBook = _dbContext.Book.Remove(Book).Entity;

            if (deletedBook == null)
            {
                return RedirectToPage("/NotFound");
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
