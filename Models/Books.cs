using System.ComponentModel.DataAnnotations;

namespace ProyectoEnjoyBook.Models
{
    public class Books
    {
        public int Id { get; set; }
        [Required]
        public string NombreLibro { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int Paginas { get; set; }
        public string EstadoLibro { get; set; }
    }
}
