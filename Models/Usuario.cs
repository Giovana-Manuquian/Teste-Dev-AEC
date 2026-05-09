using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDevAEC.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string UsuarioLogin { get; set; } = string.Empty;

        [Required]
        public byte[] SenhaSalt { get; set; } = Array.Empty<byte>();

        [Required]
        public byte[] SenhaHash { get; set; } = Array.Empty<byte>();
    }
}