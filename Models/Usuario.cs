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
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string UsuarioLogin { get; set; } // Nome alterado para não conflitar com a classe

        [Required]
        [StringLength(255)]
        public string Senha { get; set; }
    }
}