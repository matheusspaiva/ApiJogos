using CatalogoJogos.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>();
        public Task Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, double preco)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return (Task<Jogo>)Task.CompletedTask;
        }

        public Task<List<Jogo>> obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina-1)* quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> obter(Guid id)
        {
            if (jogos.ContainsKey(id))
            {
                return null;
            }
            else
            {
                return Task.FromResult(jogos[id]);
            }
        }

        public Task<List<Jogo>> obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogos => jogos.Nome.Equals(nome) && jogos.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();
            foreach(var jogo in jogos.Values)
            {
                if(jogo.Nome==nome && jogo.Produtora== produtora)
                {
                    retorno.Add(jogo);
                }
            }
            return Task.FromResult(retorno);
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return (Task<Jogo>)Task.CompletedTask;
        }
    }
}
