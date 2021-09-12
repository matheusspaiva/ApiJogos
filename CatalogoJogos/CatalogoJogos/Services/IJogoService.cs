using CatalogoJogos.InputModel;
using CatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Services
{
    public interface IJogoService: IDisposable
    {
        Task<List<JogoView>> obter(int pagina, int quantidade);
        Task<JogoView> obter(Guid id);
        Task<JogoView> Inserir(JogoInput jogo);
        Task Atualizar(Guid id, JogoInput jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
