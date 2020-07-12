using Context.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context.DatabaseContext
{
    public class BookListContext : DbContext
    {
        public BookListContext(DbContextOptions<BookListContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
