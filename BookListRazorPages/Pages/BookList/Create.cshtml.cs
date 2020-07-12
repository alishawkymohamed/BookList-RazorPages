using Context.DbObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repos;
using System.Threading.Tasks;

namespace BookListRazorPages.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Book> repository;

        [BindProperty]
        public Book Book { get; set; }

        public CreateModel(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await this.repository.Add(Book);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}