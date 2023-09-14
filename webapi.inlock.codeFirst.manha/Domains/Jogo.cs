using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codeFirst.manha.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo e obrigatorio!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao do jogo obrigatoria")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento obrigatoria")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage = "Preco do jogo obrigatorio!")]
        public decimal Preco { get; set; }



        //Referencia da chave estrangeira (Tabela de estudio)

        [Required(ErrorMessage = "Informe o estudio que produziu o jogo")]
        public Guid IdEstudio { get; set; }


        [ForeignKey("IdEstudio")]
        public Estudio Estudio { get; set; }
    }
}
