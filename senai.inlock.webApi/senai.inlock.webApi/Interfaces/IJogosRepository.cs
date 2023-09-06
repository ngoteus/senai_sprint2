using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public class IJogosRepository
    {

        ///tipoRetorno NomeMetodo(tipoParametro nomeParametro)
        void CadastrarJogo(JogosDomain jogo);

        ///Listar todos os objetos cadastrados <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com objetos</returns>
        List<JogosDomain> ListarJogo();
    }
}
