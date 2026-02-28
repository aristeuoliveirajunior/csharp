using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipes
{
    public class MeuJogo
    {
      
        public char[] posicoes { get; set; }


        public string QuemFezAUltimaJogada { get; set; }

        public string SimboloSelecionadoPrimeiro { get; set; }



        public MeuJogo()
        {
           
            this.posicoes = new char[9];

            this.QuemFezAUltimaJogada = "";
            this.SimboloSelecionadoPrimeiro = "";

            this.posicoes[0] = '\0';
            this.posicoes[1] = '\0';
            this.posicoes[2] = '\0';
            this.posicoes[3] = '\0';
            this.posicoes[4] = '\0';
            this.posicoes[5] = '\0';
            this.posicoes[6] = '\0';
            this.posicoes[7] = '\0';
            this.posicoes[8] = '\0';
        }

    }
}
