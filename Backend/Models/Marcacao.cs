using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using beckend.Enums;

namespace Backend.Models
{
    public class Marcacao
    {
        [Key]
        public int Id { get; set; }

        public string? Data { get; set; }

        public string? Horario { get; set; }

        public Status Status { get; set; }

        public int IdUser { get; set; }
        
        [ForeignKey("IdUser")]
        public User? User { get; set; }
    }
}