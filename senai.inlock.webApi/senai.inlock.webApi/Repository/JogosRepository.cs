using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source =NOTE04-S14; Initial Catalog =Filmes; User Id = sa; Pwd = Senai@134";

        



    
    public  List<JogosDomain> ListarTodos()
    {
        List<JogosDomain> ListaJogos = new List<JogosDomain>();
        
            //Delcara a sqlconnection utilizando a string conexao como parametro
        using (SqlConnection con =  new SqlConnection(StringConexao))
        {
                // declara a instrucao a ser utilizada no sql
                string querySelectAll = "SELECT Jogo.IdJogo, Jogo.IdEstudio, Jogo.Nome, Jogo.Descricao, Jogo.Datalancamento, Jogo.Valor Estudio.Nome, Estudio.IdEstudio FROM Jogo LEFT JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                //abre a conexao com o banco de dados
                con.Open();

                SqlDataReader rdr;

                //Declara o sqlcommando que fara uma consulta utilizando o queryselectall e a conexao desejada
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read()) 
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),

                            IdEstudio = Convert.ToInt32(rdr[1]),

                            Nome = rdr[2].ToString(),

                            Descricao = rdr[3].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr[4]),

                            Valor = float.Parse(rdr["Valor"]),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr[4]),
                                Nome = rdr[3].ToString()
                            }
                        };

                        ListaJogos.Add(jogo);
                    }
                }
        }
        return ListaJogos;
    }
    
    public void CadastrarJogo(JogosDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                string queryInsert = "INSERT INTO Jogo(IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES(@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                using (SqlCommand cmd = SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }




    }
}
