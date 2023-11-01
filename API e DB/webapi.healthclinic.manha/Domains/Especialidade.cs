using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialdiade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Tipo de especialidade obrigatorio!")]
        public string? TipoDeEspecialidade { get; set; }
    }
}
