using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context.DbObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;

namespace BookListRazorPages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IRepository<Book> repository;

        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await this.repository.GetAll();
            return Ok(new
            {
                data = books
            });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await this.repository.GetById(id);
            if (book == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "Error while deleting !!"
                });
            }
            else
            {
                await this.repository.Remove(book);
                return Ok(new
                {
                    success = true,
                    message = "Deleted successfully"
                });
            }
        }
    }
}
