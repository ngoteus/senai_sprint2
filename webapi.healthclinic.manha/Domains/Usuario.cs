using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Key]

        
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuario obrigatorio!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Email obrigatorio!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Senha obrigatoria!")]
        public string? Senha { get; set; }
         
        [Required(ErrorMessage = "Informe o tipo de usuario")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
