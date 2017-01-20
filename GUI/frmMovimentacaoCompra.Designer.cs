namespace GUI
{
    partial class frmMovimentacaoCompra
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
            this.components = new System.ComponentModel.Container();
            this.pnDados = new System.Windows.Forms.Panel();
            this.btnTipoPagamento = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnAdicionaFornecedor = new System.Windows.Forms.Button();
            this.cbxFornecedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.nudNumeroParcelas = new System.Windows.Forms.NumericUpDown();
            this.cbxProduto = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxTipoPagamento = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpDataInicialPagamento = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddProduto = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNFiscal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dgvItensCompra = new System.Windows.Forms.DataGridView();
            this.proCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proVnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proVtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnBotoes = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.pnFinalizaCompra = new System.Windows.Forms.Panel();
            this.lblTotalCompra = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCancelarPagamento = new System.Windows.Forms.Button();
            this.btnSalvarPagamento = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.pco_cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pco_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pco_datavecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMensagem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.pnDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensCompra)).BeginInit();
            this.pnBotoes.SuspendLayout();
            this.pnFinalizaCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.btnTipoPagamento);
            this.pnDados.Controls.Add(this.btnProduto);
            this.pnDados.Controls.Add(this.btnAdicionaFornecedor);
            this.pnDados.Controls.Add(this.cbxFornecedor);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.lblTotalItens);
            this.pnDados.Controls.Add(this.label21);
            this.pnDados.Controls.Add(this.lblValorUnitario);
            this.pnDados.Controls.Add(this.nudQuantidade);
            this.pnDados.Controls.Add(this.nudNumeroParcelas);
            this.pnDados.Controls.Add(this.cbxProduto);
            this.pnDados.Controls.Add(this.label19);
            this.pnDados.Controls.Add(this.cbxTipoPagamento);
            this.pnDados.Controls.Add(this.label14);
            this.pnDados.Controls.Add(this.label13);
            this.pnDados.Controls.Add(this.dtpDataInicialPagamento);
            this.pnDados.Controls.Add(this.label12);
            this.pnDados.Controls.Add(this.label11);
            this.pnDados.Controls.Add(this.label10);
            this.pnDados.Controls.Add(this.btnAddProduto);
            this.pnDados.Controls.Add(this.label9);
            this.pnDados.Controls.Add(this.label8);
            this.pnDados.Controls.Add(this.label7);
            this.pnDados.Controls.Add(this.label6);
            this.pnDados.Controls.Add(this.label2);
            this.pnDados.Controls.Add(this.txtNFiscal);
            this.pnDados.Controls.Add(this.label1);
            this.pnDados.Controls.Add(this.txtCodigo);
            this.pnDados.Controls.Add(this.dgvItensCompra);
            this.pnDados.Location = new System.Drawing.Point(12, 8);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(760, 403);
            this.pnDados.TabIndex = 2;
            // 
            // btnTipoPagamento
            // 
            this.btnTipoPagamento.Location = new System.Drawing.Point(147, 366);
            this.btnTipoPagamento.Name = "btnTipoPagamento";
            this.btnTipoPagamento.Size = new System.Drawing.Size(25, 25);
            this.btnTipoPagamento.TabIndex = 54;
            this.btnTipoPagamento.Text = "+";
            this.tlpMensagem.SetToolTip(this.btnTipoPagamento, "Adicionar Item");
            this.btnTipoPagamento.UseVisualStyleBackColor = true;
            this.btnTipoPagamento.Click += new System.EventHandler(this.btnTipoPagamento_Click);
            // 
            // btnProduto
            // 
            this.btnProduto.Location = new System.Drawing.Point(356, 130);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(25, 25);
            this.btnProduto.TabIndex = 5;
            this.btnProduto.Text = "+";
            this.tlpMensagem.SetToolTip(this.btnProduto, "Adicionar Fornecedor");
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnAdicionaFornecedor
            // 
            this.btnAdicionaFornecedor.Location = new System.Drawing.Point(358, 65);
            this.btnAdicionaFornecedor.Name = "btnAdicionaFornecedor";
            this.btnAdicionaFornecedor.Size = new System.Drawing.Size(25, 25);
            this.btnAdicionaFornecedor.TabIndex = 3;
            this.btnAdicionaFornecedor.Text = "+";
            this.tlpMensagem.SetToolTip(this.btnAdicionaFornecedor, "Adicionar Fornecedor");
            this.btnAdicionaFornecedor.UseVisualStyleBackColor = true;
            this.btnAdicionaFornecedor.Click += new System.EventHandler(this.btnAdicionaFornecedor_Click);
            // 
            // cbxFornecedor
            // 
            this.cbxFornecedor.FormattingEnabled = true;
            this.cbxFornecedor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxFornecedor.Location = new System.Drawing.Point(20, 67);
            this.cbxFornecedor.Name = "cbxFornecedor";
            this.cbxFornecedor.Size = new System.Drawing.Size(332, 21);
            this.cbxFornecedor.TabIndex = 2;
            this.cbxFornecedor.Leave += new System.EventHandler(this.cbxFornecedor_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Fornecedor";
            // 
            // lblTotalItens
            // 
            this.lblTotalItens.AutoSize = true;
            this.lblTotalItens.BackColor = System.Drawing.Color.Red;
            this.lblTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItens.Location = new System.Drawing.Point(570, 367);
            this.lblTotalItens.Name = "lblTotalItens";
            this.lblTotalItens.Size = new System.Drawing.Size(45, 24);
            this.lblTotalItens.TabIndex = 49;
            this.lblTotalItens.Text = "0,00";
            this.lblTotalItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(536, 367);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 24);
            this.label21.TabIndex = 50;
            this.label21.Text = "R$";
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.BackColor = System.Drawing.Color.Red;
            this.lblValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorUnitario.Location = new System.Drawing.Point(523, 131);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(45, 24);
            this.lblValorUnitario.TabIndex = 43;
            this.lblValorUnitario.Text = "0,00";
            this.lblValorUnitario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Location = new System.Drawing.Point(384, 133);
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(104, 20);
            this.nudQuantidade.TabIndex = 6;
            this.nudQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudNumeroParcelas
            // 
            this.nudNumeroParcelas.Location = new System.Drawing.Point(177, 369);
            this.nudNumeroParcelas.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudNumeroParcelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroParcelas.Name = "nudNumeroParcelas";
            this.nudNumeroParcelas.Size = new System.Drawing.Size(120, 20);
            this.nudNumeroParcelas.TabIndex = 9;
            this.nudNumeroParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumeroParcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroParcelas.ValueChanged += new System.EventHandler(this.nudNumeroParcelas_ValueChanged);
            // 
            // cbxProduto
            // 
            this.cbxProduto.FormattingEnabled = true;
            this.cbxProduto.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxProduto.Location = new System.Drawing.Point(20, 133);
            this.cbxProduto.Name = "cbxProduto";
            this.cbxProduto.Size = new System.Drawing.Size(332, 21);
            this.cbxProduto.TabIndex = 4;
            this.cbxProduto.SelectedIndexChanged += new System.EventHandler(this.cbxProduto_SelectedIndexChanged);
            this.cbxProduto.Leave += new System.EventHandler(this.cbxProduto_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(493, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 24);
            this.label19.TabIndex = 43;
            this.label19.Text = "R$";
            // 
            // cbxTipoPagamento
            // 
            this.cbxTipoPagamento.FormattingEnabled = true;
            this.cbxTipoPagamento.Location = new System.Drawing.Point(20, 369);
            this.cbxTipoPagamento.Name = "cbxTipoPagamento";
            this.cbxTipoPagamento.Size = new System.Drawing.Size(123, 21);
            this.cbxTipoPagamento.TabIndex = 8;
            this.cbxTipoPagamento.SelectedIndexChanged += new System.EventHandler(this.cbxTipoPagamento_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(571, 353);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(299, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Data Inicial do Pagamento";
            // 
            // dtpDataInicialPagamento
            // 
            this.dtpDataInicialPagamento.Location = new System.Drawing.Point(302, 369);
            this.dtpDataInicialPagamento.Name = "dtpDataInicialPagamento";
            this.dtpDataInicialPagamento.Size = new System.Drawing.Size(227, 20);
            this.dtpDataInicialPagamento.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Tipo de Pagamento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(174, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Número de Parcelas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Itens da Compra";
            // 
            // btnAddProduto
            // 
            this.btnAddProduto.Location = new System.Drawing.Point(713, 131);
            this.btnAddProduto.Name = "btnAddProduto";
            this.btnAddProduto.Size = new System.Drawing.Size(25, 25);
            this.btnAddProduto.TabIndex = 7;
            this.btnAddProduto.Text = "+";
            this.tlpMensagem.SetToolTip(this.btnAddProduto, "Adicionar Item");
            this.btnAddProduto.UseVisualStyleBackColor = true;
            this.btnAddProduto.Click += new System.EventHandler(this.btnAddProduto_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(494, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Valor Unitário";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Quantidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Produto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(721, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "_________________________________________________________________________________" +
    "______________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Número da Nota Fiscal";
            // 
            // txtNFiscal
            // 
            this.txtNFiscal.Location = new System.Drawing.Point(148, 23);
            this.txtNFiscal.Name = "txtNFiscal";
            this.txtNFiscal.Size = new System.Drawing.Size(204, 20);
            this.txtNFiscal.TabIndex = 1;
            this.txtNFiscal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFiscal_KeyPress);
            this.txtNFiscal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNFiscal_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(20, 23);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(123, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // dgvItensCompra
            // 
            this.dgvItensCompra.AllowUserToAddRows = false;
            this.dgvItensCompra.AllowUserToDeleteRows = false;
            this.dgvItensCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proCod,
            this.forNome,
            this.forQtd,
            this.proVnd,
            this.proVtotal});
            this.dgvItensCompra.Location = new System.Drawing.Point(20, 177);
            this.dgvItensCompra.Name = "dgvItensCompra";
            this.dgvItensCompra.ReadOnly = true;
            this.dgvItensCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensCompra.Size = new System.Drawing.Size(717, 174);
            this.dgvItensCompra.TabIndex = 7;
            this.dgvItensCompra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItensCompra_CellDoubleClick);
            // 
            // proCod
            // 
            this.proCod.HeaderText = "Código ";
            this.proCod.Name = "proCod";
            this.proCod.ReadOnly = true;
            this.proCod.Width = 60;
            // 
            // forNome
            // 
            this.forNome.HeaderText = "Nome";
            this.forNome.Name = "forNome";
            this.forNome.ReadOnly = true;
            this.forNome.Width = 300;
            // 
            // forQtd
            // 
            this.forQtd.HeaderText = "Quantidade";
            this.forQtd.Name = "forQtd";
            this.forQtd.ReadOnly = true;
            // 
            // proVnd
            // 
            this.proVnd.HeaderText = "Valor Unitário";
            this.proVnd.Name = "proVnd";
            this.proVnd.ReadOnly = true;
            // 
            // proVtotal
            // 
            this.proVtotal.HeaderText = "Valor Total";
            this.proVtotal.Name = "proVtotal";
            this.proVtotal.ReadOnly = true;
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btnLimpar);
            this.pnBotoes.Controls.Add(this.btnAvancar);
            this.pnBotoes.Controls.Add(this.btnCancelar);
            this.pnBotoes.Controls.Add(this.btnLocalizar);
            this.pnBotoes.Location = new System.Drawing.Point(12, 418);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(760, 114);
            this.pnBotoes.TabIndex = 3;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = global::GUI.Properties.Resources.Cancelar;
            this.btnLimpar.Location = new System.Drawing.Point(648, 6);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 100);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlpMensagem.SetToolTip(this.btnLimpar, "Limpar");
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Enabled = false;
            this.btnAvancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvancar.Image = global::GUI.Properties.Resources.Ultimo;
            this.btnAvancar.Location = new System.Drawing.Point(436, 6);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(100, 100);
            this.btnAvancar.TabIndex = 2;
            this.btnAvancar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlpMensagem.SetToolTip(this.btnAvancar, "Avançar");
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::GUI.Properties.Resources.Excluir;
            this.btnCancelar.Location = new System.Drawing.Point(224, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 100);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlpMensagem.SetToolTip(this.btnCancelar, "Cancelar Compra");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizar.Image = global::GUI.Properties.Resources.localizar_fw;
            this.btnLocalizar.Location = new System.Drawing.Point(12, 6);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(100, 100);
            this.btnLocalizar.TabIndex = 0;
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlpMensagem.SetToolTip(this.btnLocalizar, "Localizar");
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // pnFinalizaCompra
            // 
            this.pnFinalizaCompra.Controls.Add(this.lblTotalCompra);
            this.pnFinalizaCompra.Controls.Add(this.label23);
            this.pnFinalizaCompra.Controls.Add(this.label15);
            this.pnFinalizaCompra.Controls.Add(this.btnCancelarPagamento);
            this.pnFinalizaCompra.Controls.Add(this.btnSalvarPagamento);
            this.pnFinalizaCompra.Controls.Add(this.label16);
            this.pnFinalizaCompra.Controls.Add(this.label5);
            this.pnFinalizaCompra.Controls.Add(this.dgvParcelas);
            this.pnFinalizaCompra.Controls.Add(this.label17);
            this.pnFinalizaCompra.Location = new System.Drawing.Point(778, 8);
            this.pnFinalizaCompra.Name = "pnFinalizaCompra";
            this.pnFinalizaCompra.Size = new System.Drawing.Size(460, 537);
            this.pnFinalizaCompra.TabIndex = 4;
            this.pnFinalizaCompra.Visible = false;
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.AutoSize = true;
            this.lblTotalCompra.BackColor = System.Drawing.Color.Red;
            this.lblTotalCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompra.Location = new System.Drawing.Point(375, 444);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(45, 24);
            this.lblTotalCompra.TabIndex = 51;
            this.lblTotalCompra.Text = "0,00";
            this.lblTotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(345, 444);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 24);
            this.label23.TabIndex = 52;
            this.label23.Text = "R$";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(346, 429);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Total da Compra";
            // 
            // btnCancelarPagamento
            // 
            this.btnCancelarPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarPagamento.Image = global::GUI.Properties.Resources.Cancelar;
            this.btnCancelarPagamento.Location = new System.Drawing.Point(236, 423);
            this.btnCancelarPagamento.Name = "btnCancelarPagamento";
            this.btnCancelarPagamento.Size = new System.Drawing.Size(100, 100);
            this.btnCancelarPagamento.TabIndex = 1;
            this.btnCancelarPagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlpMensagem.SetToolTip(this.btnCancelarPagamento, "Cancelar");
            this.btnCancelarPagamento.UseVisualStyleBackColor = true;
            this.btnCancelarPagamento.Click += new System.EventHandler(this.btnCancelarPagamento_Click);
            // 
            // btnSalvarPagamento
            // 
            this.btnSalvarPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarPagamento.Image = global::GUI.Properties.Resources.Salvar1_fw;
            this.btnSalvarPagamento.Location = new System.Drawing.Point(108, 423);
            this.btnSalvarPagamento.Name = "btnSalvarPagamento";
            this.btnSalvarPagamento.Size = new System.Drawing.Size(100, 100);
            this.btnSalvarPagamento.TabIndex = 0;
            this.btnSalvarPagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlpMensagem.SetToolTip(this.btnSalvarPagamento, "Salvar");
            this.btnSalvarPagamento.UseVisualStyleBackColor = true;
            this.btnSalvarPagamento.Click += new System.EventHandler(this.btnSalvarPagamento_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Parcelas da Compra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Dados do Pagamento";
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pco_cod,
            this.pco_valor,
            this.pco_datavecto});
            this.dgvParcelas.Location = new System.Drawing.Point(12, 73);
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.ReadOnly = true;
            this.dgvParcelas.Size = new System.Drawing.Size(436, 340);
            this.dgvParcelas.TabIndex = 0;
            // 
            // pco_cod
            // 
            this.pco_cod.HeaderText = "Parcela";
            this.pco_cod.Name = "pco_cod";
            this.pco_cod.ReadOnly = true;
            // 
            // pco_valor
            // 
            this.pco_valor.HeaderText = "Valor da Parcela";
            this.pco_valor.Name = "pco_valor";
            this.pco_valor.ReadOnly = true;
            // 
            // pco_datavecto
            // 
            this.pco_datavecto.HeaderText = "Data do Vencimento";
            this.pco_datavecto.Name = "pco_datavecto";
            this.pco_datavecto.ReadOnly = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(415, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "____________________________________________________________________";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus,
            this.tssMensagem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tssStatus.Size = new System.Drawing.Size(0, 17);
            this.tssStatus.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tssMensagem
            // 
            this.tssMensagem.Name = "tssMensagem";
            this.tssMensagem.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMovimentacaoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnFinalizaCompra);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.pnBotoes);
            this.Name = "frmMovimentacaoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentaçao da Compra";
            this.Load += new System.EventHandler(this.frmMovimentacaoCompra_Load);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensCompra)).EndInit();
            this.pnBotoes.ResumeLayout(false);
            this.pnFinalizaCompra.ResumeLayout(false);
            this.pnFinalizaCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.Panel pnBotoes;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNFiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dgvItensCompra;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpDataInicialPagamento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn proCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn forNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn forQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn proVnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn proVtotal;
        private System.Windows.Forms.ComboBox cbxTipoPagamento;
        private System.Windows.Forms.Panel pnFinalizaCompra;
        private System.Windows.Forms.Button btnCancelarPagamento;
        private System.Windows.Forms.Button btnSalvarPagamento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvParcelas;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_datavecto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssMensagem;
        private System.Windows.Forms.ComboBox cbxProduto;
        private System.Windows.Forms.ToolTip tlpMensagem;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.NumericUpDown nudNumeroParcelas;
        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.Label lblTotalCompra;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnAdicionaFornecedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.ComboBox cbxFornecedor;
        private System.Windows.Forms.Button btnTipoPagamento;
    }
}