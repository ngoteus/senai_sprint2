using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuariobuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);
                if (usuariobuscado == null)
                {
                    return NotFound("Email e senha invalidos!");
                }
                var claims = new[]
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, usuariobuscado.IdUsuario.ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, usuariobuscado.Email),
                    new Claim(ClaimTypes.Role, usuariobuscado.IdTipoUsuario.ToString()),

                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim personalizada","Valor da claim personalizada")
                };

                //2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chaves-autenticacao-webapi-dev"));

                //3 - Definir as credencias do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - Gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "senai.inlock.webApi",

                    //destinatario do token
                    audience: "senai.inlock.webApi",

                    //dados definidos nas claims(informacoes)
                    claims: claims,

                    //tempo de expiracao de token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds

                );
                //5 - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

    }
}
