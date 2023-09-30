using Microsoft.EntityFrameworkCore;
using ProyectoEnjoyBook.Models;

namespace ProyectoEnjoyBook.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext>options):base(options)
        {

        }
        //Crear nuestro dbset
        public DbSet<Books> BooksItems { get; set; }
    }
}
