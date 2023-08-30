using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Domains
{
    public class FilmeDomain:GeneroDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O Genero e obrigatorio")]
        public string? Titulo { get; set; } 
       
       
        public int IdGenero { get; set; }
        ///                                 |
        /// Referencia para a classe genero--
        
        public GeneroDomain? Genero { get; set; }
                
    }
}
