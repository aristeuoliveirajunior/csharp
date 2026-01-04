using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedMemory
{
    public partial class Form1 : Form
    {
        private string[,] posicoes = new string[3,3];
        public Form1()
        {
            InitializeComponent();
        }

        private string validaValor(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return "X";
            else if (valor == "X")
                return "O";
            else
                return "";
        }
        private void btn1_Click(object sender, EventArgs e)
        {
           
            posicoes[0, 0] = validaValor(posicoes[0, 0]);
            btn1.Text = posicoes[0, 0];

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            posicoes[0, 1] = validaValor(posicoes[0, 1]);
            btn2.Text = posicoes[0, 1];
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            posicoes[0, 2] = validaValor(posicoes[0, 2]);
            btn3.Text = posicoes[0, 2];
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            posicoes[1, 0] = validaValor(posicoes[1, 0]);
            btn4.Text = posicoes[1, 0];
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            posicoes[1, 1] = validaValor(posicoes[1, 1]);
            btn5.Text = posicoes[1, 1];
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            posicoes[1, 2] = validaValor(posicoes[1, 2]);
            btn6.Text = posicoes[1, 2];
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            posicoes[2, 0] = validaValor(posicoes[2, 0]);
            btn7.Text = posicoes[2, 0];
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            posicoes[2, 1] = validaValor(posicoes[2, 1]);
            btn8.Text = posicoes[2,1];
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            posicoes[2, 2] = validaValor(posicoes[2, 2]);
            btn9.Text = posicoes[2, 2];
        }
    }
}
