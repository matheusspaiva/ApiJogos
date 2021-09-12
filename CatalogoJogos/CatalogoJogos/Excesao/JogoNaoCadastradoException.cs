using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Excesao
{
    public class JogoNaoCadastradoException: Exception
    {
        public JogoNaoCadastradoException() : base("Este jogo não foi cadastrado") { }
    }
}
