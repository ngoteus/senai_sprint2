using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain : TiposUsuarioDomain
    {
        public int IdUsuario { get; set; }

        //Referencia a tipoUsuarioDomain
        public int IdTipoUsuario { get; set; }

        
        [Required(ErrorMessage = "O Email e obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha e obrigatorio")]
        public string Senha { get; set; }
    }
}
