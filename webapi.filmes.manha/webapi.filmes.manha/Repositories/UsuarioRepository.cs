using System.Data.SqlClient;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{
    public class UsuarioRepository : IUsuarioInterface
    {
        private string StringConexao = "Data Source =NOTE04-S14; Initial Catalog =Filmes; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
              string emailzinho =  "SELECT Email, Senha, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(emailzinho, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Permissao = Convert.ToBoolean(rdr["Permissao"])
                        };
                        return usuario;
                    }
                    return null;
                }

            }
        }
    }
}
