using webapi.evento_.manha.Context;
using webapi.evento_.manha.Domains;
using webapi.evento_.manha.Interfaces;

namespace webapi.evento_.manha.Repositories
{
    public class InstituicaoRepository
    {
        public class InstituicaoRepository : IInstituicaoRepository
        {
            private readonly EventContext _context;

            public InstituicaoRepository()
            {
                _context = new EventContext();
            }

            public void Atualizar(Guid id, Instituicao instituicao)
            {
                try
                {
                    Instituicao instituicaoBuscada = _context.Instituicao.Find(id)!;

                    if (instituicaoBuscada != null)
                    {
                        instituicaoBuscada.CNPJ = instituicao.CNPJ;
                        instituicaoBuscada.Endereco = instituicao.Endereco;
                        instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                    }

                    _context.Instituicao.Update(instituicaoBuscada!);

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public Instituicao BuscarPorId(Guid id)
            {
                try
                {
                    return _context.Instituicao.Find(id)!;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public void Cadastrar(Instituicao instituicao)
            {
                try
                {
                    _context.Instituicao.Add(instituicao);

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public void Deletar(Guid id)
            {
                try
                {
                    Instituicao InstituicaoBuscada = _context.Instituicao.Find(id)!;

                    if (InstituicaoBuscada != null)
                    {
                        _context.Instituicao.Remove(InstituicaoBuscada);
                    }

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public List<Instituicao> Listar()
            {
                try
                {
                    return _context.Instituicao.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
