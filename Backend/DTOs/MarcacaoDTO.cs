using beckend.Enums;

namespace Backend.DTOs
{
    public class MarcacaoDTO
    {
        public string? Data { get; set; }
        public string? Horario { get; set; }
        public Status Status { get; set; }
    }
}