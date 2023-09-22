using System.ComponentModel.DataAnnotations;
using beckend.Enums;

namespace beckend.Models
{
    public class Marcacao
    {
        [Key]
        public int Id { get; set; }
        public string? Data { get; set; }
        public string? Horario { get; set; }
        public Status Status { get; set; }
    }
}