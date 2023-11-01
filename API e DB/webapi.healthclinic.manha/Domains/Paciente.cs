using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]

        public Guid IdPacientes { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Usuario obrigatorio!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome do paciente é obrigatorio!")]
        public string? NomePaciente { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Data do nascimento é obrigatorio!")]
        public string? DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "Telefone e obrigatorio!")]
        public string? Telefone { get; set; }
    }
}
