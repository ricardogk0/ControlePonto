using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string? FullName { get; set; }
        [Column("login")]
        public string? Login { get; set; }
        [Column("password")]
        public string? Password { get; set; }
    }
}