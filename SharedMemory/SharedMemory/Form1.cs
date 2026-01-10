using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedMemory
{
    public partial class Form1 : Form
    {
        MemoryMappedFile posicoes;
        private string tipo;

        public Form1()
        {
            InitializeComponent();

            funcaoConferenciaMemoria();

        }
        
        private void funcaoThreadConfereMemoria()
        {
            if(InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    if (posicoes != null)
                    {

                        btn1.Text = getValor(0).ToString();
                        btn2.Text = getValor(1).ToString();
                        btn3.Text = getValor(2).ToString();

                        btn4.Text = getValor(3).ToString();
                        btn5.Text = getValor(4).ToString();
                        btn6.Text = getValor(5).ToString();

                        btn7.Text = getValor(6).ToString();
                        btn8.Text = getValor(7).ToString();
                        btn9.Text = getValor(8).ToString();

                    }

                }));

                return;
            }
           
        }

        private void funcaoConferenciaMemoria()
        {


            Thread th = new Thread(() =>
            {
                while (true)
                {
                    funcaoThreadConfereMemoria();
                    Thread.Sleep(1000);
                }
            });

            th.IsBackground = true;
            th.Start();
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
            if (valor== '\0' && tipo=="LetraX")
                return 'X';
            else if (valor == '\0' && tipo=="Circulo")
                return 'O';
            else
                return valor;
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

            setValorPosicao(btn1,0);
           

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn2, 1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn3, 2);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn4, 3);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn5, 4);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn6, 5);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn7, 6);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn8, 7);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn9, 8);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarMemoria();
        }


        private void chkCirculo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCirculo.Checked)
            {
                tipo = "Circulo";
            }
        }

        private void chkLetraX_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLetraX.Checked)
            {
                tipo = "LetraX";
            }
        }
    }
}
