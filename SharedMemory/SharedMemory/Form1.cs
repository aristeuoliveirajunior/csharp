using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;

namespace SharedMemory
{
    public partial class Form1 : Form
    {
        MemoryMappedFile posicoes;

        public Form1()
        {
            InitializeComponent();

             long tamanho = 9 * sizeof(char);

             posicoes = MemoryMappedFile.CreateOrOpen("sharedMemory", tamanho);
        }

        private char validaValor(char valor)
        {
            if (valor== '\0')
                return 'X';
            else if (valor == 'X')
                return 'O';
            else
                return '\0';
        }

        private char getValor(int linha, int coluna)
        {
            var access = posicoes.CreateViewAccessor();

            int posicao= linha * coluna * sizeof(char);

            return access.ReadChar(posicao);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var access = posicoes.CreateViewAccessor();

            int linha = 0;
            int coluna = 0;
            int posicao = linha * coluna * sizeof(char);

            access.ReadChar(posicao);

            posicoes[0, 0] = validaValor(getValor(0,0));
            btn1.Text = posicoes[0, 0].ToString();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            posicoes[0, 1] = validaValor(getValor(0, 1));
            btn2.Text = posicoes[0, 1].ToString();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            posicoes[0, 2] = validaValor(getValor(0, 2));
            btn3.Text = posicoes[0, 2].ToString();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            posicoes[1, 0] = validaValor(getValor(1, 0));
            btn4.Text = posicoes[1, 0].ToString();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            posicoes[1, 1] = validaValor(getValor(1, 1));
            btn5.Text = posicoes[1, 1].ToString();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            posicoes[1, 2] = validaValor(getValor(1, 2));
            btn6.Text = posicoes[1, 2].ToString();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            posicoes[2, 0] = validaValor(getValor(2, 0));
            btn7.Text = posicoes[2, 0].ToString();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            posicoes[2, 1] = validaValor(getValor(2, 1));
            btn8.Text = posicoes[2,1].ToString();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            posicoes[2, 2] = validaValor(getValor(2, 2));
            btn9.Text = posicoes[2, 2].ToString();
        }
    }
}
