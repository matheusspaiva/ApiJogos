using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.InputModel
{
    public class JogoInput
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve ter de 3 a 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve ter de 1 a 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "O preço do jogo é de 1 real até 1.000 reais")]
        public double Preco { get; set; }
    }
}
