using CatalogoJogos.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repository
{
    public interface IJogoRepository: IDisposable
    {
        Task<List<Jogo>> obter(int pagina, int quantidade);
        Task<Jogo> obter(Guid id);
        Task<List<Jogo>> obter(string nome, string produtora);
        Task<Jogo> Inserir(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
        Task<List<Jogo>> ObterSemLambda(string nome, string produtora);
    }
}
