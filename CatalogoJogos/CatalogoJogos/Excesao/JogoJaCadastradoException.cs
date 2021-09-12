using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Excessao
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException(): base("Este jogo já foi cadastrado") { }
    }
}
