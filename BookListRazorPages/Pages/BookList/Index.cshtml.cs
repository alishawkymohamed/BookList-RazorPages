using Context.DbObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazorPages.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Book> repository;
        public IEnumerable<Book> Books { get; set; }
        public IndexModel(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task OnGet()
        {
            Books = await repository.GetAll();
        }

        public async Task<ActionResult> OnPostRemove(int id)
        {
            var book = await this.repository.GetById(id);
            if (book != null)
            {
                await this.repository.Remove(book);
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}