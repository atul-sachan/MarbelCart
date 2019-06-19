using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCurdDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCurdDemo.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await this.context.Books.AddAsync(Book);
            await this.context.SaveChangesAsync();
            Message = "Record created successfully";
            return RedirectToPage("Index");

        }
    }
}