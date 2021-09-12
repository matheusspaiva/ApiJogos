using CatalogoJogos.Enity;
using CatalogoJogos.Excesao;
using CatalogoJogos.Excessao;
using CatalogoJogos.InputModel;
using CatalogoJogos.Repository;
using CatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _JogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _JogoRepository = jogoRepository;

        }

        public async Task Atualizar(Guid id, JogoInput jogo)
        {
            var entidade = await _JogoRepository.obter(id);
            if(entidade == null)
            {
                throw new JogoNaoCadastradoException();
            }
            else
            {
                entidade.Nome = jogo.Nome;
                entidade.Produtora = jogo.Produtora;
                entidade.Preco = jogo.Preco;
                await _JogoRepository.Atualizar( entidade);
            }
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidade = await _JogoRepository.obter(id);
            if (entidade == null)
            {
                throw new JogoNaoCadastradoException();
            }
            else
            {

                entidade.Preco = entidade.Preco;
                await _JogoRepository.Atualizar(entidade);
            }
        }

        public void Dispose()
        {
            _JogoRepository.Dispose();
        }

        public async Task<JogoView> Inserir(JogoInput jogo)
        {
            var entidadeJogo = await _JogoRepository.obter(jogo.Nome, jogo.Produtora);
            if (entidadeJogo.Count > 0)
            {
                throw new JogoJaCadastradoException();
            }
            else
            {
                var jogoinsert = new Jogo
                {
                    Id = Guid.NewGuid(),
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Preco = jogo.Preco
                };
                await _JogoRepository.Inserir(jogoinsert);
                return new JogoView
                {
                    Id = jogoinsert.Id,
                    Nome = jogoinsert.Nome,
                    Produtora = jogoinsert.Produtora,
                    Preco = jogoinsert.Preco
                };
            }
        }

        public async Task<List<JogoView>> obter(int pagina, int quantidade)
        {
            var jogos = await _JogoRepository.obter(pagina, quantidade);
            return jogos.Select(jogo => new JogoView
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco

            }).ToList();
        }

        public async Task<JogoView> obter(Guid id)
        {
            var jogo = await _JogoRepository.obter(id);
            if (jogo == null)
            {
                return null;
            }
            else
            {
                return new JogoView
                {
                    Id = jogo.Id,
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Preco = jogo.Preco

                };
            }
        }



        public async Task Remover(Guid id)
        {
            var entidadeJogo = await _JogoRepository.obter(id);
            if (entidadeJogo ==  null)
            {
                throw new JogoNaoCadastradoException();
            }
            else
            {
                await _JogoRepository.Remover(id);
            }
        }
    }
}
