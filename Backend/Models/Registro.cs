using System.ComponentModel.DataAnnotations;

namespace beckend.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }
        public Marcacao? Entrada { get; set; }
        public Marcacao? Saida { get; set; }
    }
}