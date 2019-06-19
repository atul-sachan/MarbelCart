using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCurdDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCurdDemo.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet(int id)
        {
            Book = this.context.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = this.context.Books.Find(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.Author = Book.Author;

                await this.context.SaveChangesAsync();
                Message = " Book updated succesfully";
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}