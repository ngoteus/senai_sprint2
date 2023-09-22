using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.evento_.manha.Domains
{
    [Table(nameof(PresencasEvento))]
    public class PresencasEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situacao obrigatoria!")]
        public bool Situacao { get; set; }

        //ref.tabela Usuario = FK
        public Guid  IdUsuario  { get; set; }

        [ForeignKey(nameof(IdUsuario))]

        public Usuario? Usuario { get; set; }

        //ref.tabela Evento = FK
        [Required(ErrorMessage = "Evento obrigatorio!")]

        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]

        public Evento? Evento { get; set; }
    }
}
