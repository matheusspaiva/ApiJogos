using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.ViewModel
{
    public class JogoView
    {
        //public JogoView(Guid Id, string Nome, string Produtora, double preco)
        //{

       // }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { set; get; }
    }
}
