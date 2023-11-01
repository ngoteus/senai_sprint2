using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]

        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Descricao obrigatoria!")]
        public string? Descricao { get; set; }


        [Required(ErrorMessage = "Paciente obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Consulta obrigatoria!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]

        public Consulta? Consulta { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Titulo do comentario obrigatorio!")]
        public string? TiutloComentario { get; set; }



    }
}
