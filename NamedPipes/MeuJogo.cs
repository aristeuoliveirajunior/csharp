using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipes
{
    public class MeuJogo
    {
        public string Tipo { get; set; } = "";

        public bool JoqueiPorUltimo { get; set; }

        public char posicao1 { get; set; }

        public char posicao2 { get; set; }

        public char posicao3 { get; set; }

        public char posicao4 { get; set; }

        public char posicao5 { get; set; }

        public char posicao6 { get; set; }

        public char posicao7 { get; set; }

        public char posicao8 { get; set; }

        public char posicao9 { get; set; }


        public MeuJogo()
        {
            this.Tipo = "";
            this.JoqueiPorUltimo = false;
            this.posicao1 = '\0';
            this.posicao2 = '\0';
            this.posicao3 = '\0';
            this.posicao4 = '\0';
            this.posicao5 = '\0';
            this.posicao6 = '\0';
            this.posicao7 = '\0';
            this.posicao8= '\0';
            this.posicao9 = '\0';
        }

    }
}
