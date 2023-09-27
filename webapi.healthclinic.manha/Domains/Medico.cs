using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]

        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Especialidade obrigatória!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        [Required(ErrorMessage = "Usuario obrigatorio!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))] 
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Clinica obrigatorio!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]

        public Clinica? Clinica { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome do medico obrigatorio!")]
        public string? NomeMedico { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "CRM e obrigatorio!")]
        public string? CRM { get; set; }

    }
}
