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

           
        }

       

        private void enviarMensagemPipe()
        {
            string json=JsonSerializer.Serialize(meuJogo);
            byte[] data = Encoding.UTF8.GetBytes(json);

            if(pipe!=null)
                pipe.Write(data, 0, data.Length);
            else
                pipeCliente.Write(data, 0, data.Length);
        }

        private async Task<MeuJogo?> lerMensagemPipe()
        {

            int t = 0;
            
                string message = "";
                byte[] data = new byte[100];

                do
                {
                    try
                    {
                        if (pipe != null && pipe.IsConnected)
                            t = await pipe.ReadAsync(data, 0, data.Length, new CancellationTokenSource(2000).Token);
                        else if (pipeCliente != null && pipeCliente.IsConnected)
                            t = await pipeCliente.ReadAsync(data, 0, data.Length, new CancellationTokenSource(2000).Token);
                        else
                            return null;
                        if (t > 0)
                        message += Encoding.UTF8.GetString(data, 0, t);
                    }
                    catch 
                    {
                         return null;
                    }
                   
                } while (((pipe!=null && !pipe.IsMessageComplete)|| (pipeCliente != null && !pipeCliente.IsMessageComplete)) && t>0);


                if(!string.IsNullOrEmpty(message))
                {
                    MeuJogo? jogoAdversario = JsonSerializer.Deserialize<MeuJogo>(message);

                    if (jogoAdversario != null)
                    {
                        meuJogo = jogoAdversario;
                    }
                }
                

            return meuJogo;
                
            }

     

        private void criarNamedPipe(MeuJogo meuJogo)
        {

            if(string.IsNullOrEmpty(txtNomeJogo.Text))
            {
                MessageBox.Show("Defina o nome do jogo, o seu adversário deve definir o mesmo nome!");
                return;
            }

            if (string.IsNullOrEmpty(txtNomeJogador.Text))
            {
                MessageBox.Show("Defina o seu nome de jogador!");
                return;
            }

            try
            {
                pipe = new NamedPipeServerStream(txtNomeJogo.Text, PipeDirection.InOut, 1, PipeTransmissionMode.Message);
            }
            catch(Exception ex)
            {

            }

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
                    Thread.Sleep(3000);
                }
            });

            th.IsBackground = true;
            th.Start();
        }

        private  void funcaoThreadConferePipe()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(async () =>
                {
                    MeuJogo? jogoAdversario=await lerMensagemPipe();

                    if (jogoAdversario != null)
                    {

                        btn1.Text = getValorJogoAdversario(jogoAdversario,0).ToString();
                        btn2.Text = getValorJogoAdversario(jogoAdversario, 1).ToString();
                        btn3.Text = getValorJogoAdversario(jogoAdversario, 2).ToString();

                        btn4.Text = getValorJogoAdversario(jogoAdversario, 3).ToString();
                        btn5.Text = getValorJogoAdversario(jogoAdversario, 4).ToString();
                        btn6.Text = getValorJogoAdversario(jogoAdversario, 5).ToString();

                        btn7.Text = getValorJogoAdversario(jogoAdversario, 6).ToString();
                        btn8.Text = getValorJogoAdversario(jogoAdversario, 7).ToString();
                        btn9.Text = getValorJogoAdversario(jogoAdversario, 8).ToString();

                        this.meuJogo = jogoAdversario;

                    }

                }));

                return;
            }

        }

        private async void ConectarNamedPipe(string servidor, string nomeJogo)
        {
            try
            {
                servidor = servidor.Trim();

                pipeCliente = new NamedPipeClientStream(servidor, nomeJogo, PipeDirection.InOut,PipeOptions.Asynchronous);

                pipeCliente.Connect(10000);

                pipeCliente.ReadMode = PipeTransmissionMode.Message;

                MessageBox.Show("Conexão estabelecida com adversário.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Não foi possível conectar ao adversário");
            }



        }

       

        private void reiniciarJogo()
        {


            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(async () =>
                {
                    MeuJogo? novoJogo = new MeuJogo();

                    if (novoJogo != null)
                    {

                        btn1.Text = getValorJogoAdversario(novoJogo, 0).ToString();
                        btn2.Text = getValorJogoAdversario(novoJogo, 1).ToString();
                        btn3.Text = getValorJogoAdversario(novoJogo, 2).ToString();

                        btn4.Text = getValorJogoAdversario(novoJogo, 3).ToString();
                        btn5.Text = getValorJogoAdversario(novoJogo, 4).ToString();
                        btn6.Text = getValorJogoAdversario(novoJogo, 5).ToString();

                        btn7.Text = getValorJogoAdversario(novoJogo, 6).ToString();
                        btn8.Text = getValorJogoAdversario(novoJogo, 7).ToString();
                        btn9.Text = getValorJogoAdversario(novoJogo, 8).ToString();

                        this.meuJogo = novoJogo;

                    }

                }));

                return;
            }
        }

       

        private bool setTipoSelecionadoPrimeiro(string tipo)
        {
            
            meuJogo.Tipo = tipo;

            return true;
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

       
        

        private void setValorPosicao(Button btn, int posicao)
        {
            char valor = validaValor(getValor(posicao));
            bool resultado= setValor(posicao, valor);
            if (resultado)
            {
                btn.Text = valor.ToString();
            }
            
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

        private char getValorJogoAdversario(MeuJogo? jogoAdversario,int coluna)
        {
            if(jogoAdversario!=null)
                return jogoAdversario.posicoes[coluna];
            return '\0';
        }

        private bool setValor(int coluna, char valor)
        {
            if (getValor(coluna) == 'X' || getValor(coluna) == 'O')
            {
                MessageBox.Show("Esta posição já foi preenchida!");
                return false; ;
            }
            if (valor == '\0')
            {
                MessageBox.Show("Você deve selecionar o seu símbolo para jogar");
                return false;
            }
            if (meuJogo.QuemFezAUltimaJogada == txtNomeJogador.Text)
            {
                MessageBox.Show("Você já jogou, aguarde a jogada do colega!");
                return false;
            }

            meuJogo.posicoes[coluna] = valor;
            meuJogo.QuemFezAUltimaJogada = txtNomeJogador.Text;

            enviarMensagemPipe();

            return true;
           
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
