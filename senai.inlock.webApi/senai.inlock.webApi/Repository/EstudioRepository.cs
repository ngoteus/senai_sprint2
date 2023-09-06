using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os seguintes parametros:
        /// Data Source: Nome do Servidor
        /// Intital Catalog : Nome Do Banco de dados
        /// Autenticacao:
        ///     -Windows : Integrated Security =  true
        ///     -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source =NOTE04-S14; Initial Catalog =Filmes; User Id = sa; Pwd = Senai@134";


        public void Cadastrar(EstudioDomain estudioDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "Insert into Estudio(Nome) VALUES (@Nome)";
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudioDomain.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };
                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }

    }
}
