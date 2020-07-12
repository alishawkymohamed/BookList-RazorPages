using Context.DbObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repos;
using System.Threading.Tasks;

namespace BookListRazorPages.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Book> repository;

        [BindProperty]
        public Book Book { get; set; }
        public EditModel(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task OnGet(int id)
        {
            Book = await this.repository.GetById(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await this.repository.Update(Book);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}