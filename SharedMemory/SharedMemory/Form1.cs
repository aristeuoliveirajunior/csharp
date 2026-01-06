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


             
        }

        private void inicializarMemoria()
        {

            long tamanho = 9 * sizeof(char);
            posicoes = MemoryMappedFile.CreateOrOpen("sharedMemory", tamanho);
        }

        private void setValorPosicao(Button btn, int posicao)
        {
            char valor = validaValor(getValor(posicao));
            btn.Text = valor.ToString();
            setValor(posicao, valor);
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

        private char getValor(int coluna)
        {
            var access = posicoes.CreateViewAccessor();

            int posicao=  coluna * sizeof(char);

            return access.ReadChar(posicao);
        }

        private void setValor(int coluna,char valor)
        {
            var access = posicoes.CreateViewAccessor();

            int posicao = coluna * sizeof(char);

             access.Write<char>(posicao,ref valor);
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            setValorPosicao(btn1,1);
           

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn2, 2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn3, 3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn4, 4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn5, 5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn6, 6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn7, 7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn8, 8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn9, 9);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarMemoria();
        }
    }
}
