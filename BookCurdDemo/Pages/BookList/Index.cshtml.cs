using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCurdDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookCurdDemo.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public IEnumerable<Book> Books { get; set; }
        public string HelloMessage { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task OnGet()
        {
            this.HelloMessage = "BookList";
            this.Books = await this.context.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await this.context.Books.FindAsync(id);
            this.context.Remove(book);
            await this.context.SaveChangesAsync();

            Message = "Book deleted succesfully";

            return RedirectToPage("Index");
        }
    }
}