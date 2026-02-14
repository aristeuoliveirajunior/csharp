namespace NamedPipes
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            chkCirculo = new CheckBox();
            chkLetraX = new CheckBox();
            bntReiniciar = new Button();
            txtAdversarioIP = new TextBox();
            label2 = new Label();
            btnConectarAdversario = new Button();
            btnPermitirConexoesRemotas = new Button();
            txtNomeJogo = new TextBox();
            label1 = new Label();
            txtNomeJogador = new TextBox();
            label3 = new Label();
            btnDefinirNomeJogador = new Button();
            label4 = new Label();
            lblNomeJogador = new Label();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn1.Location = new Point(209, 130);
            btn1.Margin = new Padding(3, 4, 3, 4);
            btn1.Name = "btn1";
            btn1.Size = new Size(177, 121);
            btn1.TabIndex = 0;
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn2.Location = new Point(383, 130);
            btn2.Margin = new Padding(3, 4, 3, 4);
            btn2.Name = "btn2";
            btn2.Size = new Size(177, 121);
            btn2.TabIndex = 1;
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn3.Location = new Point(552, 130);
            btn3.Margin = new Padding(3, 4, 3, 4);
            btn3.Name = "btn3";
            btn3.Size = new Size(177, 121);
            btn3.TabIndex = 2;
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn4.Location = new Point(209, 246);
            btn4.Margin = new Padding(3, 4, 3, 4);
            btn4.Name = "btn4";
            btn4.Size = new Size(177, 121);
            btn4.TabIndex = 3;
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn5.Location = new Point(383, 246);
            btn5.Margin = new Padding(3, 4, 3, 4);
            btn5.Name = "btn5";
            btn5.Size = new Size(177, 121);
            btn5.TabIndex = 4;
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn6.Location = new Point(552, 246);
            btn6.Margin = new Padding(3, 4, 3, 4);
            btn6.Name = "btn6";
            btn6.Size = new Size(177, 121);
            btn6.TabIndex = 5;
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn7
            // 
            btn7.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn7.Location = new Point(209, 362);
            btn7.Margin = new Padding(3, 4, 3, 4);
            btn7.Name = "btn7";
            btn7.Size = new Size(177, 121);
            btn7.TabIndex = 6;
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn8.Location = new Point(383, 362);
            btn8.Margin = new Padding(3, 4, 3, 4);
            btn8.Name = "btn8";
            btn8.Size = new Size(177, 121);
            btn8.TabIndex = 7;
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn9.Location = new Point(552, 362);
            btn9.Margin = new Padding(3, 4, 3, 4);
            btn9.Name = "btn9";
            btn9.Size = new Size(177, 121);
            btn9.TabIndex = 8;
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // chkCirculo
            // 
            chkCirculo.AutoSize = true;
            chkCirculo.Location = new Point(643, 502);
            chkCirculo.Margin = new Padding(3, 4, 3, 4);
            chkCirculo.Name = "chkCirculo";
            chkCirculo.Size = new Size(77, 24);
            chkCirculo.TabIndex = 9;
            chkCirculo.Text = "Círculo";
            chkCirculo.UseVisualStyleBackColor = true;
            chkCirculo.CheckedChanged += chkCirculo_CheckedChanged;
            // 
            // chkLetraX
            // 
            chkLetraX.AutoSize = true;
            chkLetraX.Location = new Point(643, 547);
            chkLetraX.Margin = new Padding(3, 4, 3, 4);
            chkLetraX.Name = "chkLetraX";
            chkLetraX.Size = new Size(77, 24);
            chkLetraX.TabIndex = 10;
            chkLetraX.Text = "Letra X";
            chkLetraX.UseVisualStyleBackColor = true;
            chkLetraX.CheckedChanged += chkLetraX_CheckedChanged;
            // 
            // bntReiniciar
            // 
            bntReiniciar.Location = new Point(209, 491);
            bntReiniciar.Margin = new Padding(3, 4, 3, 4);
            bntReiniciar.Name = "bntReiniciar";
            bntReiniciar.Size = new Size(162, 80);
            bntReiniciar.TabIndex = 11;
            bntReiniciar.Text = "Reiniciar";
            bntReiniciar.UseVisualStyleBackColor = true;
            bntReiniciar.Click += bntReiniciar_Click;
            // 
            // txtAdversarioIP
            // 
            txtAdversarioIP.Location = new Point(209, 702);
            txtAdversarioIP.Name = "txtAdversarioIP";
            txtAdversarioIP.Size = new Size(167, 27);
            txtAdversarioIP.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 679);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 14;
            label2.Text = "Adversário IP";
            // 
            // btnConectarAdversario
            // 
            btnConectarAdversario.Location = new Point(392, 688);
            btnConectarAdversario.Margin = new Padding(3, 4, 3, 4);
            btnConectarAdversario.Name = "btnConectarAdversario";
            btnConectarAdversario.Size = new Size(208, 41);
            btnConectarAdversario.TabIndex = 16;
            btnConectarAdversario.Text = "Conectar com adversário";
            btnConectarAdversario.UseVisualStyleBackColor = true;
            btnConectarAdversario.Click += btnConectarAdversario_Click;
            // 
            // btnPermitirConexoesRemotas
            // 
            btnPermitirConexoesRemotas.Location = new Point(209, 595);
            btnPermitirConexoesRemotas.Margin = new Padding(3, 4, 3, 4);
            btnPermitirConexoesRemotas.Name = "btnPermitirConexoesRemotas";
            btnPermitirConexoesRemotas.Size = new Size(520, 45);
            btnPermitirConexoesRemotas.TabIndex = 17;
            btnPermitirConexoesRemotas.Text = "Permitir Conexão com Adversário";
            btnPermitirConexoesRemotas.UseVisualStyleBackColor = true;
            btnPermitirConexoesRemotas.Click += btnPermitirConexoesRemotas_Click;
            // 
            // txtNomeJogo
            // 
            txtNomeJogo.Location = new Point(209, 96);
            txtNomeJogo.Name = "txtNomeJogo";
            txtNomeJogo.Size = new Size(511, 27);
            txtNomeJogo.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(209, 73);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 12;
            label1.Text = "Nome do Jogo";
            // 
            // txtNomeJogador
            // 
            txtNomeJogador.Location = new Point(209, 782);
            txtNomeJogador.Name = "txtNomeJogador";
            txtNomeJogador.Size = new Size(391, 27);
            txtNomeJogador.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(209, 759);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 18;
            label3.Text = "Nome do Jogador";
            // 
            // btnDefinirNomeJogador
            // 
            btnDefinirNomeJogador.Location = new Point(618, 768);
            btnDefinirNomeJogador.Margin = new Padding(3, 4, 3, 4);
            btnDefinirNomeJogador.Name = "btnDefinirNomeJogador";
            btnDefinirNomeJogador.Size = new Size(208, 41);
            btnDefinirNomeJogador.TabIndex = 20;
            btnDefinirNomeJogador.Text = "Definir Nome Jogador";
            btnDefinirNomeJogador.UseVisualStyleBackColor = true;
            btnDefinirNomeJogador.Click += btnDefinirNomeJogador_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(209, 26);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 21;
            // 
            // lblNomeJogador
            // 
            lblNomeJogador.AutoSize = true;
            lblNomeJogador.Font = new Font("Segoe UI", 12F);
            lblNomeJogador.Location = new Point(214, 29);
            lblNomeJogador.Name = "lblNomeJogador";
            lblNomeJogador.Size = new Size(197, 28);
            lblNomeJogador.TabIndex = 22;
            lblNomeJogador.Text = "Jogador: _____________";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 828);
            Controls.Add(lblNomeJogador);
            Controls.Add(label4);
            Controls.Add(btnDefinirNomeJogador);
            Controls.Add(txtNomeJogador);
            Controls.Add(label3);
            Controls.Add(btnPermitirConexoesRemotas);
            Controls.Add(btnConectarAdversario);
            Controls.Add(txtAdversarioIP);
            Controls.Add(label2);
            Controls.Add(txtNomeJogo);
            Controls.Add(label1);
            Controls.Add(bntReiniciar);
            Controls.Add(chkLetraX);
            Controls.Add(chkCirculo);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Jogo da Velha";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.CheckBox chkCirculo;
        private System.Windows.Forms.CheckBox chkLetraX;
        private System.Windows.Forms.Button bntReiniciar;
        private TextBox txtAdversarioIP;
        private Label label2;
        private Button btnConectarAdversario;
        private Button btnPermitirConexoesRemotas;
        private TextBox txtNomeJogo;
        private Label label1;
        private TextBox txtNomeJogador;
        private Label label3;
        private Button btnDefinirNomeJogador;
        private Label label4;
        private Label lblNomeJogador;
    }
}

