namespace GUI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnidadeMedida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTipoPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaSubCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaUnidadeMedida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConsultaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConsultaTipoPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConsultaCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConsultaUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPagamentoCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPagamentoVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguracaoBanco = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCalculadora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBlocoNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.stsRodape = new System.Windows.Forms.StatusStrip();
            this.tssStatusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.lklLogout = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.grbLogin.SuspendLayout();
            this.stsRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastro,
            this.mnuConsulta,
            this.mnuMovimentacao,
            this.mnuRelatorio,
            this.mnuFerramentas,
            this.mnuSobre});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCadastro
            // 
            this.mnuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategoria,
            this.mnuSubCategoria,
            this.mnuUnidadeMedida,
            this.mnuProduto,
            this.toolStripSeparator1,
            this.mnuCliente,
            this.mnuFornecedor,
            this.toolStripSeparator4,
            this.mnuTipoPagamento,
            this.toolStripSeparator8,
            this.mnuUsuario});
            this.mnuCadastro.Name = "mnuCadastro";
            this.mnuCadastro.Size = new System.Drawing.Size(66, 20);
            this.mnuCadastro.Text = "Cadastro";
            this.mnuCadastro.Visible = false;
            // 
            // mnuCategoria
            // 
            this.mnuCategoria.Name = "mnuCategoria";
            this.mnuCategoria.Size = new System.Drawing.Size(178, 22);
            this.mnuCategoria.Text = "Categoria";
            this.mnuCategoria.Visible = false;
            this.mnuCategoria.Click += new System.EventHandler(this.mnuCategoria_Click);
            // 
            // mnuSubCategoria
            // 
            this.mnuSubCategoria.Name = "mnuSubCategoria";
            this.mnuSubCategoria.Size = new System.Drawing.Size(178, 22);
            this.mnuSubCategoria.Text = "Sub Categoria";
            this.mnuSubCategoria.Visible = false;
            this.mnuSubCategoria.Click += new System.EventHandler(this.mnuSubCategoria_Click);
            // 
            // mnuUnidadeMedida
            // 
            this.mnuUnidadeMedida.Name = "mnuUnidadeMedida";
            this.mnuUnidadeMedida.Size = new System.Drawing.Size(178, 22);
            this.mnuUnidadeMedida.Text = "Unidade de Medida";
            this.mnuUnidadeMedida.Visible = false;
            this.mnuUnidadeMedida.Click += new System.EventHandler(this.mnuUnidadeMedida_Click);
            // 
            // mnuProduto
            // 
            this.mnuProduto.Name = "mnuProduto";
            this.mnuProduto.Size = new System.Drawing.Size(178, 22);
            this.mnuProduto.Text = "Produto";
            this.mnuProduto.Visible = false;
            this.mnuProduto.Click += new System.EventHandler(this.mnuProduto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuCliente
            // 
            this.mnuCliente.Name = "mnuCliente";
            this.mnuCliente.Size = new System.Drawing.Size(178, 22);
            this.mnuCliente.Text = "Cliente ";
            this.mnuCliente.Visible = false;
            this.mnuCliente.Click += new System.EventHandler(this.mnuCliente_Click);
            // 
            // mnuFornecedor
            // 
            this.mnuFornecedor.Name = "mnuFornecedor";
            this.mnuFornecedor.Size = new System.Drawing.Size(178, 22);
            this.mnuFornecedor.Text = "Fornecedor";
            this.mnuFornecedor.Visible = false;
            this.mnuFornecedor.Click += new System.EventHandler(this.mnuFornecedor_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuTipoPagamento
            // 
            this.mnuTipoPagamento.Name = "mnuTipoPagamento";
            this.mnuTipoPagamento.Size = new System.Drawing.Size(178, 22);
            this.mnuTipoPagamento.Text = "Tipo de Pagamento";
            this.mnuTipoPagamento.Visible = false;
            this.mnuTipoPagamento.Click += new System.EventHandler(this.mnuTipoPagamento_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(178, 22);
            this.mnuUsuario.Text = "Usuário";
            this.mnuUsuario.Visible = false;
            this.mnuUsuario.Click += new System.EventHandler(this.mnuUsuario_Click);
            // 
            // mnuConsulta
            // 
            this.mnuConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConsultaCategoria,
            this.mnuConsultaSubCategoria,
            this.mnuConsultaUnidadeMedida,
            this.mnuConsultaProduto,
            this.toolStripSeparator2,
            this.mnuConsultaCliente,
            this.mnuConsultaFornecedor,
            this.toolStripSeparator5,
            this.mnuConsultaTipoPagamento,
            this.toolStripSeparator6,
            this.mnuConsultaCompra,
            this.mnuConsultaVenda,
            this.toolStripSeparator9,
            this.mnuConsultaUsuario});
            this.mnuConsulta.Name = "mnuConsulta";
            this.mnuConsulta.Size = new System.Drawing.Size(66, 20);
            this.mnuConsulta.Text = "Consulta";
            this.mnuConsulta.Visible = false;
            // 
            // mnuConsultaCategoria
            // 
            this.mnuConsultaCategoria.Name = "mnuConsultaCategoria";
            this.mnuConsultaCategoria.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaCategoria.Text = "Categoria";
            this.mnuConsultaCategoria.Visible = false;
            this.mnuConsultaCategoria.Click += new System.EventHandler(this.mnuConsultaCategoria_Click);
            // 
            // mnuConsultaSubCategoria
            // 
            this.mnuConsultaSubCategoria.Name = "mnuConsultaSubCategoria";
            this.mnuConsultaSubCategoria.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaSubCategoria.Text = "Sub Categoria";
            this.mnuConsultaSubCategoria.Visible = false;
            this.mnuConsultaSubCategoria.Click += new System.EventHandler(this.mnuConsultaSubCategoria_Click);
            // 
            // mnuConsultaUnidadeMedida
            // 
            this.mnuConsultaUnidadeMedida.Name = "mnuConsultaUnidadeMedida";
            this.mnuConsultaUnidadeMedida.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaUnidadeMedida.Text = "Unidade de Medida";
            this.mnuConsultaUnidadeMedida.Visible = false;
            this.mnuConsultaUnidadeMedida.Click += new System.EventHandler(this.mnuConsultaUnidadeMedida_Click);
            // 
            // mnuConsultaProduto
            // 
            this.mnuConsultaProduto.Name = "mnuConsultaProduto";
            this.mnuConsultaProduto.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaProduto.Text = "Produto";
            this.mnuConsultaProduto.Visible = false;
            this.mnuConsultaProduto.Click += new System.EventHandler(this.mnuConsultaProduto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuConsultaCliente
            // 
            this.mnuConsultaCliente.Name = "mnuConsultaCliente";
            this.mnuConsultaCliente.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaCliente.Text = "Cliente";
            this.mnuConsultaCliente.Visible = false;
            this.mnuConsultaCliente.Click += new System.EventHandler(this.mnuConsultaCliente_Click);
            // 
            // mnuConsultaFornecedor
            // 
            this.mnuConsultaFornecedor.Name = "mnuConsultaFornecedor";
            this.mnuConsultaFornecedor.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaFornecedor.Text = "Fornecedor";
            this.mnuConsultaFornecedor.Visible = false;
            this.mnuConsultaFornecedor.Click += new System.EventHandler(this.mnuConsultaFornecedor_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuConsultaTipoPagamento
            // 
            this.mnuConsultaTipoPagamento.Name = "mnuConsultaTipoPagamento";
            this.mnuConsultaTipoPagamento.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaTipoPagamento.Text = "Tipo de Pagamento";
            this.mnuConsultaTipoPagamento.Visible = false;
            this.mnuConsultaTipoPagamento.Click += new System.EventHandler(this.mnuConsultaTipoPagamento_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuConsultaCompra
            // 
            this.mnuConsultaCompra.Name = "mnuConsultaCompra";
            this.mnuConsultaCompra.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaCompra.Text = "Compra";
            this.mnuConsultaCompra.Visible = false;
            this.mnuConsultaCompra.Click += new System.EventHandler(this.mnuConsultaCompra_Click);
            // 
            // mnuConsultaVenda
            // 
            this.mnuConsultaVenda.Name = "mnuConsultaVenda";
            this.mnuConsultaVenda.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaVenda.Text = "Venda";
            this.mnuConsultaVenda.Visible = false;
            this.mnuConsultaVenda.Click += new System.EventHandler(this.mnuConsultaVenda_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuConsultaUsuario
            // 
            this.mnuConsultaUsuario.Name = "mnuConsultaUsuario";
            this.mnuConsultaUsuario.Size = new System.Drawing.Size(178, 22);
            this.mnuConsultaUsuario.Text = "Usuário";
            this.mnuConsultaUsuario.Visible = false;
            this.mnuConsultaUsuario.Click += new System.EventHandler(this.mnuConsultaUsuario_Click);
            // 
            // mnuMovimentacao
            // 
            this.mnuMovimentacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCompra,
            this.mnuVenda,
            this.toolStripSeparator7,
            this.mnuPagamentoCompra,
            this.mnuPagamentoVenda});
            this.mnuMovimentacao.Name = "mnuMovimentacao";
            this.mnuMovimentacao.Size = new System.Drawing.Size(99, 20);
            this.mnuMovimentacao.Text = "Movimentação";
            this.mnuMovimentacao.Visible = false;
            // 
            // mnuCompra
            // 
            this.mnuCompra.Name = "mnuCompra";
            this.mnuCompra.Size = new System.Drawing.Size(181, 22);
            this.mnuCompra.Text = "Compra";
            this.mnuCompra.Visible = false;
            this.mnuCompra.Click += new System.EventHandler(this.mnuCompra_Click);
            // 
            // mnuVenda
            // 
            this.mnuVenda.Name = "mnuVenda";
            this.mnuVenda.Size = new System.Drawing.Size(181, 22);
            this.mnuVenda.Text = "Venda";
            this.mnuVenda.Visible = false;
            this.mnuVenda.Click += new System.EventHandler(this.mnuVenda_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuPagamentoCompra
            // 
            this.mnuPagamentoCompra.Name = "mnuPagamentoCompra";
            this.mnuPagamentoCompra.Size = new System.Drawing.Size(181, 22);
            this.mnuPagamentoCompra.Text = "Pagamento Compra";
            this.mnuPagamentoCompra.Visible = false;
            this.mnuPagamentoCompra.Click += new System.EventHandler(this.mnuPagamentoCompra_Click);
            // 
            // mnuPagamentoVenda
            // 
            this.mnuPagamentoVenda.Name = "mnuPagamentoVenda";
            this.mnuPagamentoVenda.Size = new System.Drawing.Size(181, 22);
            this.mnuPagamentoVenda.Text = "Pagamento Venda";
            this.mnuPagamentoVenda.Visible = false;
            this.mnuPagamentoVenda.Click += new System.EventHandler(this.mnuPagamentoVenda_Click);
            // 
            // mnuRelatorio
            // 
            this.mnuRelatorio.Name = "mnuRelatorio";
            this.mnuRelatorio.Size = new System.Drawing.Size(66, 20);
            this.mnuRelatorio.Text = "Relatório";
            this.mnuRelatorio.Visible = false;
            // 
            // mnuFerramentas
            // 
            this.mnuFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConfiguracaoBanco,
            this.mnuBackup,
            this.toolStripSeparator3,
            this.mnuCalculadora,
            this.mnuExplorer,
            this.mnuBlocoNotas,
            this.mnuCmd});
            this.mnuFerramentas.Name = "mnuFerramentas";
            this.mnuFerramentas.Size = new System.Drawing.Size(84, 20);
            this.mnuFerramentas.Text = "Ferramentas";
            this.mnuFerramentas.Visible = false;
            // 
            // mnuConfiguracaoBanco
            // 
            this.mnuConfiguracaoBanco.Name = "mnuConfiguracaoBanco";
            this.mnuConfiguracaoBanco.Size = new System.Drawing.Size(251, 22);
            this.mnuConfiguracaoBanco.Text = "Configuração do Banco de Dados";
            this.mnuConfiguracaoBanco.Visible = false;
            this.mnuConfiguracaoBanco.Click += new System.EventHandler(this.mnuConfiguracaoBanco_Click);
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(251, 22);
            this.mnuBackup.Text = "Backup do Banco de Dados";
            this.mnuBackup.Visible = false;
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuCalculadora
            // 
            this.mnuCalculadora.Name = "mnuCalculadora";
            this.mnuCalculadora.Size = new System.Drawing.Size(251, 22);
            this.mnuCalculadora.Text = "Calculadora";
            this.mnuCalculadora.Visible = false;
            this.mnuCalculadora.Click += new System.EventHandler(this.mnuCalculadora_Click);
            // 
            // mnuExplorer
            // 
            this.mnuExplorer.Name = "mnuExplorer";
            this.mnuExplorer.Size = new System.Drawing.Size(251, 22);
            this.mnuExplorer.Text = "Explorer";
            this.mnuExplorer.Visible = false;
            this.mnuExplorer.Click += new System.EventHandler(this.mnuExplorer_Click);
            // 
            // mnuBlocoNotas
            // 
            this.mnuBlocoNotas.Name = "mnuBlocoNotas";
            this.mnuBlocoNotas.Size = new System.Drawing.Size(251, 22);
            this.mnuBlocoNotas.Text = "Bloco de Notas";
            this.mnuBlocoNotas.Visible = false;
            this.mnuBlocoNotas.Click += new System.EventHandler(this.mnuBlocoNotas_Click);
            // 
            // mnuCmd
            // 
            this.mnuCmd.Name = "mnuCmd";
            this.mnuCmd.Size = new System.Drawing.Size(251, 22);
            this.mnuCmd.Text = "cmd";
            this.mnuCmd.Visible = false;
            this.mnuCmd.Click += new System.EventHandler(this.mnuCmd_Click);
            // 
            // mnuSobre
            // 
            this.mnuSobre.Name = "mnuSobre";
            this.mnuSobre.Size = new System.Drawing.Size(49, 20);
            this.mnuSobre.Text = "Sobre";
            this.mnuSobre.Visible = false;
            this.mnuSobre.Click += new System.EventHandler(this.mnuSobre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(7, 26);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 3;
            this.txtLogin.Text = "admin";
            this.txtLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLogin_KeyUp);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(115, 26);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(100, 20);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.Text = "admin";
            this.txtSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha";
            // 
            // grbLogin
            // 
            this.grbLogin.Controls.Add(this.label1);
            this.grbLogin.Controls.Add(this.txtSenha);
            this.grbLogin.Controls.Add(this.btnLogin);
            this.grbLogin.Controls.Add(this.label2);
            this.grbLogin.Controls.Add(this.txtLogin);
            this.grbLogin.Location = new System.Drawing.Point(476, 25);
            this.grbLogin.Name = "grbLogin";
            this.grbLogin.Size = new System.Drawing.Size(306, 61);
            this.grbLogin.TabIndex = 6;
            this.grbLogin.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(221, 24);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Fazer Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // stsRodape
            // 
            this.stsRodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatusLogin});
            this.stsRodape.Location = new System.Drawing.Point(0, 539);
            this.stsRodape.Name = "stsRodape";
            this.stsRodape.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stsRodape.Size = new System.Drawing.Size(784, 22);
            this.stsRodape.TabIndex = 7;
            this.stsRodape.Text = "statusStrip1";
            // 
            // tssStatusLogin
            // 
            this.tssStatusLogin.Name = "tssStatusLogin";
            this.tssStatusLogin.Size = new System.Drawing.Size(0, 17);
            this.tssStatusLogin.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // lklLogout
            // 
            this.lklLogout.AutoSize = true;
            this.lklLogout.Location = new System.Drawing.Point(732, 27);
            this.lklLogout.Name = "lklLogout";
            this.lklLogout.Size = new System.Drawing.Size(40, 13);
            this.lklLogout.TabIndex = 8;
            this.lklLogout.TabStop = true;
            this.lklLogout.Text = "Logout";
            this.lklLogout.Visible = false;
            this.lklLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklLogout_LinkClicked);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lklLogout);
            this.Controls.Add(this.stsRodape);
            this.Controls.Add(this.grbLogin);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Controle de Estoque";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbLogin.ResumeLayout(false);
            this.grbLogin.PerformLayout();
            this.stsRodape.ResumeLayout(false);
            this.stsRodape.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnuCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuSubCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuConsulta;
        private System.Windows.Forms.ToolStripMenuItem mnuMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorio;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentas;
        private System.Windows.Forms.ToolStripMenuItem mnuSobre;
        private System.Windows.Forms.ToolStripMenuItem mnuUnidadeMedida;
        private System.Windows.Forms.ToolStripMenuItem mnuProduto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuFornecedor;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaSubCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaUnidadeMedida;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaProduto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaFornecedor;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguracaoBanco;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuCalculadora;
        private System.Windows.Forms.ToolStripMenuItem mnuExplorer;
        private System.Windows.Forms.ToolStripMenuItem mnuBlocoNotas;
        private System.Windows.Forms.ToolStripMenuItem mnuCmd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuTipoPagamento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaTipoPagamento;
        private System.Windows.Forms.ToolStripMenuItem mnuCompra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaCompra;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaVenda;
        private System.Windows.Forms.ToolStripMenuItem mnuVenda;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuPagamentoCompra;
        private System.Windows.Forms.ToolStripMenuItem mnuPagamentoVenda;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbLogin;
        private System.Windows.Forms.StatusStrip stsRodape;
        private System.Windows.Forms.ToolStripStatusLabel tssStatusLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lklLogout;
    }
}