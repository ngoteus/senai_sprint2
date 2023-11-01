using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudioRepository
    {
        ///tipoRetorno NomeMetodo(tipoParametro nomeParametro)
        void Cadastrar(EstudioDomain novoEstudio);

        ///Listar todos os objetos cadastrados <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com objetos</returns>
        List<EstudioDomain> ListarTodos();
    }
}
