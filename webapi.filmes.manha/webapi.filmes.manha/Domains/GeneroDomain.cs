using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
       public int IdGenero { get; set; }
        [Required(ErrorMessage = "O nome do Gênero é obrigatorio")]
        public string Name { get; set; }

        


    }
}
