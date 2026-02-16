using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NamedPipes
{
    public partial class Form1 : Form
    {
        NamedPipeServerStream pipe;
        NamedPipeClientStream pipeCliente;

        public MeuJogo meuJogo=new MeuJogo();

        MemoryMappedFile posicoes;
        private string tipo;
        MemoryMappedFile ultimaJogada;
        MemoryMappedFile tipoSelecionadoPrimeiro;

        public Form1()
        {
            InitializeComponent();

            meuJogo = new MeuJogo();

            funcaoConferenciaMemoria();

        }

        private string serializarMeuJogo(MeuJogo meuJogo)
        {
            string json = JsonSerializer.Serialize(meuJogo);

            return json;

        }

        private void enviarMensagemPipe()
        {
            string json=JsonSerializer.Serialize(meuJogo);
            byte[] data = Encoding.UTF8.GetBytes(json);

            pipe.Write(data,0,data.Length);
        }

        private MeuJogo lerMensagemPipe()
        {
            string message = "";
            byte[] data = new byte[100];

            do
            {
                int t = pipe.Read(data, 0, data.Length);
                message += Encoding.UTF8.GetString(data, 0, t);
            } while (!pipe.IsMessageComplete);


            meuJogo = JsonSerializer.Deserialize<MeuJogo>(message);
        }

        private void criarNamedPipe(MeuJogo meuJogo)
        {


            pipe = new NamedPipeServerStream(txtNomeJogo.Text, PipeDirection.InOut, 1, PipeTransmissionMode.Message);

            Task promise = pipe.WaitForConnectionAsync();


            promise.ContinueWith(x => { MessageBox.Show("Adversário se conectou!"); });

            MessageBox.Show("Aguardando adversário solicitar conexão");


        }


        private void funcaoConferenciaPipe()
        {


            Thread th = new Thread(() =>
            {
                while (true)
                {
                    funcaoThreadConferePipe();
                    Thread.Sleep(1000);
                }
            });

            th.IsBackground = true;
            th.Start();
        }

        private void funcaoThreadConferePipe()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    if (posicoes != null)
                    {

                        btn1.Text = getValorJogoAdversario(0).ToString();
                        btn2.Text = getValorJogoAdversario(1).ToString();
                        btn3.Text = getValorJogoAdversario(2).ToString();

                        btn4.Text = getValorJogoAdversario(3).ToString();
                        btn5.Text = getValorJogoAdversario(4).ToString();
                        btn6.Text = getValorJogoAdversario(5).ToString();

                        btn7.Text = getValorJogoAdversario(6).ToString();
                        btn8.Text = getValorJogoAdversario(7).ToString();
                        btn9.Text = getValorJogoAdversario(8).ToString();

                    }

                }));

                return;
            }

        }

        private async void ConectarNamedPipe(string servidor, string nomeJogo)
        {
            try
            {
                pipeCliente = new NamedPipeClientStream(servidor, nomeJogo, PipeDirection.InOut);

                pipeCliente.Connect(10000);

                MessageBox.Show("Conexão estabelecida com adversário.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar ao adversário");
            }



        }

        private void enviarParaNamedPipe(MeuJogo meuJogo)
        {
            string json = serializarMeuJogo(meuJogo);

            NamedPipeServerStream pipe = new NamedPipeServerStream("meuJogo", PipeDirection.Out, 1, PipeTransmissionMode.Message);




            pipe.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
            pipe.Flush();
        }

        private void reiniciarJogo()
        {
            setUltimaJogada('0');

            for (int cont = 0; cont <= 8; cont++)
            {
                var access = posicoes.CreateViewAccessor();

                int posicao = cont * sizeof(char);

                char valor = '\0';

                access.Write<char>(posicao, ref valor);
            }
        }

        private void setUltimaJogada(char valor)
        {
            ultimaJogada = MemoryMappedFile.CreateOrOpen("sharedmemoryUltimaJogada", sizeof(char));
            var access = ultimaJogada.CreateViewAccessor();
            access.Write(0, valor);
        }

        private bool setTipoSelecionadoPrimeiro(string tipo)
        {
            // tipoSelecionadoPrimeiro = MemoryMappedFile.CreateOrOpen("sharedmemorytiposelecionadoprimeiro", sizeof(char));
            //var access = tipoSelecionadoPrimeiro.CreateViewAccessor();
            // char tipolido = 'c';

            // access.Read<char>(0, out tipolido);

            // if (tipo == tipolido)
            //{
            //   MessageBox.Show("Símbolo já selecionado!");
            //  chkCirculo.Checked = false;
            // chkLetraX.Checked = false;

            // return false;
            // }


            // access.Write<char>(0, ref tipo);

            meuJogo.Tipo = tipo;

            return true;
        }

        private char getUltimaJogada()
        {
            ultimaJogada = MemoryMappedFile.CreateOrOpen("sharedmemoryUltimaJogada", sizeof(char));
            var access = ultimaJogada.CreateViewAccessor();
            char v = '0';
            access.Read(0, out v);

            return v;
        }

        private bool validaVitoria()
        {
            bool vitoria = false;

            int contMarcacoes = 0;
            if (getValor(0).ToString() == tipo) contMarcacoes++;
            if (getValor(1).ToString() == tipo) contMarcacoes++;
            if (getValor(2).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;

            contMarcacoes = 0;
            if (getValor(3).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(5).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;


            contMarcacoes = 0;
            if (getValor(6).ToString() == tipo) contMarcacoes++;
            if (getValor(7).ToString() == tipo) contMarcacoes++;
            if (getValor(8).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;


            contMarcacoes = 0;
            if (getValor(0).ToString() == tipo) contMarcacoes++;
            if (getValor(3).ToString() == tipo) contMarcacoes++;
            if (getValor(6).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;


            contMarcacoes = 0;
            if (getValor(1).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(7).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;


            contMarcacoes = 0;
            if (getValor(2).ToString() == tipo) contMarcacoes++;
            if (getValor(5).ToString() == tipo) contMarcacoes++;
            if (getValor(8).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;


            contMarcacoes = 0;
            if (getValor(0).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(8).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;


            contMarcacoes = 0;
            if (getValor(2).ToString() == tipo) contMarcacoes++;
            if (getValor(4).ToString() == tipo) contMarcacoes++;
            if (getValor(6).ToString() == tipo) contMarcacoes++;

            if (contMarcacoes == 3) vitoria = true;

            return vitoria;


        }

        private void funcaoThreadConfereMemoria()
        {
            if (InvokeRequired)
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

        

        private void setValorPosicao(Button btn, int posicao)
        {
            char valor = validaValor(getValor(posicao));
            btn.Text = valor.ToString();
            setValor(posicao, valor);
        }

        private char validaValor(char valor)
        {
            if (valor == '\0' && tipo == "X")
                return 'X';
            else if (valor == '\0' && tipo == "O")
                return 'O';
            else
                return valor;
        }

        private char getValor(int coluna)
        {
            return meuJogo.posicoes[coluna];
        }

        private char getValorJogoAdversario(int coluna)
        {
            lerMensagemPipe();

            return meuJogo.posicoes[coluna];
        }

        private void setValor(int coluna, char valor)
        {
            if (getValor(coluna) == 'X' || getValor(coluna) == 'O')
            {
                MessageBox.Show("Esta posição já foi preenchida!");
                return;
            }
            if (valor == '\0')
            {
                MessageBox.Show("Você deve selecionar o seu símbolo para jogar");
                return;
            }
            if (getUltimaJogada() == valor)
            {
                MessageBox.Show("Você já jogou, aguarde a jogada do colega!");
                return;
            }

            meuJogo.posicoes[coluna] = valor;

            enviarMensagemPipe();

            setUltimaJogada(valor);
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            setValorPosicao(btn1, 0);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn2, 1);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn3, 2);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn4, 3);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn5, 4);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn6, 5);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn7, 6);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn8, 7);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            setValorPosicao(btn9, 8);
            bool result = validaVitoria();

            if (result)
            {
                MessageBox.Show("Parabéns você venceu!");
                reiniciarJogo();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            funcaoConferenciaPipe();
        }


        private void chkCirculo_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Você já selecionou o seu símbolo, não é possível trocar");
                chkCirculo.Checked = false;
                return;
            }

            if (chkCirculo.Checked)
            {

                if (setTipoSelecionadoPrimeiro("O"))
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
                if (setTipoSelecionadoPrimeiro("X"))
                    tipo = "X";
            }

        }

        private void bntReiniciar_Click(object sender, EventArgs e)
        {
            MeuJogo meu = new MeuJogo();
            meu.Tipo = "Circulo";


            reiniciarJogo();

        }

        private void btnPermitirConexoesRemotas_Click(object sender, EventArgs e)
        {
            MeuJogo meuJogo = new MeuJogo();
            criarNamedPipe(meuJogo);


        }

        private void btnConectarAdversario_Click(object sender, EventArgs e)
        {
            ConectarNamedPipe(txtAdversarioIP.Text, txtNomeJogo.Text);
        }

        private void btnDefinirNomeJogador_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNomeJogador.Text))
            {
                MessageBox.Show("Defina o nome do jogador!");
                return;
            }

            meuJogo.NomeJogador=txtNomeJogador.Text;
            lblNomeJogador.Text= "Jogador: " + txtNomeJogador.Text;
            
        }
    }
}
