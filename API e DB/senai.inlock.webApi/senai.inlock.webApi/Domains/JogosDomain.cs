using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class JogosDomain : EstudioDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }
        //referencia a classe estudio

        [Required(ErrorMessage = "O Nome e obrigatorio")]
        public string Nome { get; set; }

        public string Descricao { get; set;}

        public DateTime DataLancamento { get; set; }

        public float Valor { get; set; } 

        public EstudioDomain Estudio { get; set; }
    }
}
