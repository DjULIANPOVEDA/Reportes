using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEnjoyBook.Data;
using ProyectoEnjoyBook.Models;
using Microsoft.AspNetCore.Http;

namespace ProyectoEnjoyBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly BookContext _database;
        public LibrosController(BookContext database)
        {
            _database = database;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> GetBooks()
        {
            var listaLibros = await _database.BooksItems.ToListAsync();
            return Ok(listaLibros);
        }
        //-------------------------------------------------------------------

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Books request)
        {
            await _database.BooksItems.AddAsync(request);
            await _database.SaveChangesAsync();
            return Ok(request);
        }
        //--------------------------------------------------------------------

        [HttpPut]
        [Route("Actualizar/{id:int}")]

        public async Task<IActionResult> Actualizar(int id, Books item)
        {
            if (id != item.Id)
            {
                return BadRequest();   
            }

            _database.Entry(item).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return Ok(item);
        }
        //-----------------------------------------------------------------------

        [HttpDelete]
        [Route("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var EliminarLibro = await _database.BooksItems.FindAsync(id);
            if (EliminarLibro == null)
                return BadRequest("No existe el libro");

            _database.BooksItems.Remove(EliminarLibro);
            await _database.SaveChangesAsync();
            return Ok();
        }
    }
}
