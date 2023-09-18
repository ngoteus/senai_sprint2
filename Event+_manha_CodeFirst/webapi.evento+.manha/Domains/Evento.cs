using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.evento_.manha.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]

        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage ="Data do evento obrigatoria!")]

        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do evento obrigatoria!")]

        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao do evento obrigatoria")]

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O tipo do evento é obrigatorio!")]

        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set;}

        //ref.tabela Instituicao
        [Required(ErrorMessage ="Instituicao é obrigatorio")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }

    }
}
