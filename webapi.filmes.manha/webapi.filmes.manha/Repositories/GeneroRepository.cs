using System.Data.SqlClient;
using System.Reflection;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{

    public class GeneroRepository : IGeneroRepository
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


        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrL(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero"> Objeto com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
             string queryInsert = "INSERT INTO Genero(Nome) VALUES ('" + novoGenero.Nome + "')";

                //Declara o SQLCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    //Abre a conexao com o banco de dados
                    con.Open();

                    //executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
             string  querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexao com o banco de dados
                con.Open();
                
                //Declara o sQLDataReadder para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommando passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query a armazena os dados no rdr
                  rdr =  cmd.ExecuteReader();
                    while (rdr.Read()) 
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };
                        listaGeneros.Add(genero);
                    }
                }
            }
            //Retor
            return listaGeneros;
        }
    }
}



