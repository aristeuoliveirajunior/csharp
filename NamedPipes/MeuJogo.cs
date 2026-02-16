using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipes
{
    public class MeuJogo
    {
        public string Tipo { get; set; }

        public bool JoqueiPorUltimo { get; set; }

        public char[] posicoes;

        public string NomeJogador { get; set; }

        public string QuemFezAUltimaJogada { get; set; }



        public MeuJogo()
        {
           
            this.JoqueiPorUltimo = false;
            this.posicoes = new char[9];
            this.NomeJogador = "";

          
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
