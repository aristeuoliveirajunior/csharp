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
        MemoryMappedFile ultimaJogada;

        public Form1()
        {
            InitializeComponent();


            funcaoConferenciaMemoria();

        }

        private void setUltimaJogada(char valor)
        {
            ultimaJogada = MemoryMappedFile.CreateOrOpen("sharedmemoryUltimaJogada", sizeof(char));
            var access=ultimaJogada.CreateViewAccessor();
            access.Write(0,valor);
        }

        private char getUltimaJogada()
        {
            ultimaJogada = MemoryMappedFile.CreateOrOpen("sharedmemoryUltimaJogada", sizeof(char));
            var access=ultimaJogada.CreateViewAccessor();
            char v = '0';
            access.Read(0, out v);

            return v;
        }

        private bool validaVitoria()
        {
            int contMarcacoes = 0;
            if (getValor(0).ToString() == tipo) contMarcacoes++;
            if (getValor(1).ToString() == tipo) contMarcacoes++;
            if (getValor(2).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;

            contMarcacoes = 0;
            if (getValor(3).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(5).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;


            contMarcacoes = 0;
            if (getValor(6).ToString() == tipo) contMarcacoes++;
            if (getValor(7).ToString() == tipo) contMarcacoes++;
            if (getValor(8).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;


            contMarcacoes = 0;
            if (getValor(0).ToString() == tipo) contMarcacoes++;
            if (getValor(3).ToString() == tipo) contMarcacoes++;
            if (getValor(6).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;


            contMarcacoes = 0;
            if (getValor(1).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(7).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;


            contMarcacoes = 0;
            if (getValor(2).ToString() == tipo) contMarcacoes++;
            if (getValor(5).ToString() == tipo) contMarcacoes++;
            if (getValor(8).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;


            contMarcacoes = 0;
            if (getValor(0).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(8).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;


            contMarcacoes = 0;
            if (getValor(2).ToString() == tipo) contMarcacoes++;
            if (getValor(6).ToString() == tipo) contMarcacoes++;
            if (getValor(6).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) return true;

            return false;
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
            if (valor== '\0' && tipo=="X")
                return 'X';
            else if (valor == '\0' && tipo=="O")
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
            if(valor== '\0')
            {
                MessageBox.Show("Você deve selecionar o seu símbolo para jogar");
                return;
            }
            if (getUltimaJogada() == valor)
            {
                MessageBox.Show("Você já jogou, aguarde a jogada do colega!");
                return;
            }
               

            var access = posicoes.CreateViewAccessor();

            int posicao = coluna * sizeof(char);

            access.Write<char>(posicao,ref valor);

            setUltimaJogada(valor);
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            setValorPosicao(btn1,0);
            bool result=validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn2, 1);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn3, 2);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn4, 3);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn5, 4);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn6, 5);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn7, 6);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn8, 7);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn9, 8);
            bool result = validaVitoria();

            if (result) MessageBox.Show("Parabéns você venceu!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarMemoria();
        }


        private void chkCirculo_CheckedChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Você já selecionou o seu símbolo, não é possível trocar");
                chkCirculo.Checked = false;
                return;
            }

            if (chkCirculo.Checked)
            {
                tipo = "O";
            }
        }

        private void chkLetraX_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Você já selecionou o seu símbolo, não é possível trocar");
                chkLetraX.Checked = false;
                return;
            }

            if (chkLetraX.Checked)
            {
                tipo = "X";
            }
        }

        private void bntReiniciar_Click(object sender, EventArgs e)
        {
            setUltimaJogada('0');
            posicoes = MemoryMappedFile.CreateNew("sharedmemory", sizeof(char)*9);

        }
    }
}
