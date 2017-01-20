using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferramentas;
using System.Collections;
using System.Data.SqlClient;
using System.Threading;
using Ferramentas;

namespace GUI
{
    public partial class frmCadastroUsuario : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        private bool carregaComboBox;
        //frmPrincipal principal;
        #endregion

        #region "Eventos Construtor, Load e Botões"
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }
        //public frmCadastroUsuario(frmPrincipal f)
        //{
        //    InitializeComponent();
        //    principal = f;
        //}
        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            CarregaCombobox();
            if (codigo != 0)
            {
                LocalizarUsuário();
                codigo = 0;
            }
            alteraBotoes();
            txtNome.Focus();
        }
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLUsuario bll = new BLLUsuario(cx);
                ModeloUsuario modelo = bll.CarregaModeloUsuario(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                //frmConsultaUsuário f = new frmConsultaUsuário(principal);
                frmConsultaUsuário f = new frmConsultaUsuário();
                Close();
                f.ShowDialog();
                f.Dispose();
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja realmente excluir o registro? ", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                try
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                    BLLUsuario bll = new BLLUsuario(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    LimpaTela();
                    alteraBotoes();
                    txtNome.Focus();
                    Mensagem("USUÁRIO EXCLUIDO ", Color.Blue);
                }
                catch (Exception erro)
                {
                    Erro("ERRO AO EXCLUIR O USUÁRIO " + erro.Message);
                    alteraBotoes();
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloUsuario modelo = new ModeloUsuario()
                {
                    usu_nome = txtNome.Text,
                    usu_cpf = mktCpfCnpj.Text,
                    usu_rg = mktRgIe.Text,
                    usu_cep = mktCep.Text,
                    usu_estado = cbxEstado.Text,
                    usu_sgl = cbxSgl.Text,
                    usu_cidade = cbxCidade.Text,
                    usu_bairro = cbxBairro.Text,
                    usu_logradouro = cbxLogradouro.Text,
                    usu_numero = txtNumero.Text,
                    usu_complemento = txtComplemento.Text,
                    usu_email = txtEmail.Text,
                    usu_telefone = mktTelefone.Text,
                    usu_celular = mktCelular.Text,
                    usu_login = txtLogin.Text,
                    usu_senha = txtSenha.Text,
                    usu_lembretesenha = txtLembreteSenha.Text
                };
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLUsuario bll = new BLLUsuario(cx);
                if (txtCodigo.Text == "")
                {
                    bll.Inserir(modelo);
                    CadastraPermissao(modelo.usu_cod);
                    Mensagem("USUÁRIO INSERIDO CÓDIGO: " + modelo.usu_cod, Color.Blue);
                }
                else
                {
                    modelo.usu_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    CadastraPermissao(modelo.usu_cod);
                    Mensagem("USUÁRIO ATUALIZADO COM SUCESSO ", Color.Blue);
                    //AtulizaMenu();
                }
                LimpaTela();
                alteraBotoes();
            }
            catch (Exception erro)
            {
                Erro(erro.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
            alteraBotoes();
            txtNome.Focus();
        }
        #endregion

        #region "Funções"
        private void alteraBotoes()
        {
            btnExcluir.Enabled = (txtCodigo.Text.Trim().Length < 1) ? false : true;
        }
        private void LimpaTela()
        {
            //Limpar a tela
            txtCodigo.Clear();
            txtNome.Clear();
            mktCpfCnpj.Clear();
            mktRgIe.Clear();
            mktCep.Clear();
            txtEmail.Clear();
            mktTelefone.Clear();
            mktCelular.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtLembreteSenha.Clear();
            DesmarcarTodasPermissoes();
            CarregaCombobox();
        }
        private void LimpaEndereco(string campos)
        {
            carregaComboBox = false;
            if (campos == "endereco")
            {
                mktCep.Clear();
                campos = "cep";
            }
            if (campos == "cep")
            {
                cbxSgl.Text = "";
                cbxEstado.Text = "";
                cbxCidade.Text = "";
                cbxBairro.Text = "";
                cbxLogradouro.Text = "";
                txtNumero.Clear();
                chkSN.Checked = false;
                txtComplemento.Clear();
            }
            if (campos == "sigla")
            {
                cbxEstado.Text = "";
                cbxCidade.Text = "";
                cbxBairro.Text = "";
                cbxLogradouro.Text = "";
                txtNumero.Clear();
                chkSN.Checked = false;
                txtComplemento.Clear();
                campos = "estado";
            }
            if (campos == "estado")
            {
                cbxCidade.Text = "";
                cbxBairro.Text = "";
                cbxLogradouro.Text = "";
                txtNumero.Clear();
                chkSN.Checked = false;
                txtComplemento.Clear();
                campos = "cidade";
            }
            if (campos == "cidade")
            {
                cbxBairro.Text = "";
                cbxLogradouro.Text = "";
                txtNumero.Clear();
                chkSN.Checked = false;
                txtComplemento.Clear();
                campos = "bairro";
            }
            if (campos == "bairro")
            {
                cbxLogradouro.Text = "";
                txtNumero.Clear();
                chkSN.Checked = false;
                txtComplemento.Clear();
                campos = "logradouro";
            }
            if (campos == "logradouro")
            {
                txtNumero.Clear();
                chkSN.Checked = false;
                txtComplemento.Clear();
            }

        }
        private void PreencheCampos(ModeloUsuario modelo)
        {
            txtCodigo.Text = modelo.usu_cod.ToString();
            txtNome.Text = modelo.usu_nome;
            mktCpfCnpj.Text = modelo.usu_cpf;
            mktRgIe.Text = modelo.usu_rg;
            mktCep.Text = modelo.usu_cep;
            cbxSgl.Text = modelo.usu_sgl;
            cbxEstado.Text = modelo.usu_estado;
            cbxCidade.Text = modelo.usu_cidade;
            cbxBairro.Text = modelo.usu_bairro;
            cbxLogradouro.Text = modelo.usu_logradouro;
            txtComplemento.Text = modelo.usu_complemento;
            txtNumero.Text = modelo.usu_numero;
            txtEmail.Text = modelo.usu_email;
            mktTelefone.Text = modelo.usu_telefone;
            mktCelular.Text = modelo.usu_celular;
            txtLogin.Text = modelo.usu_login;
            txtSenha.Text = modelo.usu_senha;
            txtLembreteSenha.Text = modelo.usu_lembretesenha;
        }
        private void Mensagem(string mensagem, Color cor)
        {
            tssMensagem.ForeColor = cor;
            tssMensagem.Text = mensagem;
            Refresh();
            System.Threading.Thread.Sleep(2000);
            tssMensagem.Text = "";
        }
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "nome":
                    txtNome.Focus();
                    Mensagem("DIGITE O NOME DO USUÁRIO ", Color.Red);
                    break;
                case "cpf":
                    mktCpfCnpj.Focus();
                    Mensagem("CPF INVÁLIDO ", Color.Red);
                    break;
                case "rg":
                    mktRgIe.Focus();
                    Mensagem("DIGITE O RG DO USUÁRIO ", Color.Red);
                    break;
                case "cep":
                    mktCep.Focus();
                    Mensagem("DIGITE O CEP ", Color.Red);
                    break;
                case "sgl":
                    cbxSgl.Focus();
                    Mensagem("SELECIONE A SIGLA ", Color.Red);
                    break;
                case "estado":
                    cbxEstado.Focus();
                    Mensagem("SELECIONE O ESTADO ", Color.Red);
                    break;
                case "cidade":
                    cbxCidade.Focus();
                    Mensagem("SELECIONE O CIDADE", Color.Red);
                    break;
                case "bairro":
                    cbxBairro.Focus();
                    Mensagem("SELECIONE O BAIRRO", Color.Red);
                    break;
                case "logradouro":
                    cbxLogradouro.Focus();
                    Mensagem("DIGITE O ENDEREÇO ", Color.Red);
                    break;
                case "complemento":
                    txtComplemento.Focus();
                    Mensagem("DIGITE O COMPLEMENTO DO ENDEREÇO ", Color.Red);
                    break;
                case "numero":
                    txtNumero.Focus();
                    Mensagem("DIGITE O NÚMERO DO ENDEREÇO ", Color.Red);
                    break;
                case "email":
                    txtEmail.Focus();
                    Mensagem("E-MAIL INVÁLIDO ", Color.Red);
                    break;
                case "telefone":
                    mktTelefone.Focus();
                    Mensagem("DIGITE O TELEFONE DO USUÁRIO ", Color.Red);
                    break;
                case "celular":
                    mktCelular.Focus();
                    Mensagem("DIGITE O CELULAR DO USUÁRIO ", Color.Red);
                    break;
                case "login":
                    txtLogin.Focus();
                    Mensagem("DIGITE O LOGIN DO USUÁRIO ", Color.Red);
                    break;
                case "senha":
                    txtSenha.Focus();
                    Mensagem("DIGITE A SENHA DO USUÁRIO ", Color.Red);
                    break;
                case "lembretesenha":
                    txtLembreteSenha.Focus();
                    Mensagem("DIGITE UM LEMBRETE PARA A SENHA DO USUÁRIO ", Color.Red);
                    break;
                default:
                    Mensagem(erro, Color.Red);
                    break;
            }
        }
        private void MarcarTodasPermissoes()
        {
            //Permissões Cadastro
            cbxCadastro.Checked = true;
            cbxCategoria.Checked = true;
            cbxSubCategoria.Checked = true;
            cbxUnidadeDeMedida.Checked = true;
            cbxProduto.Checked = true;
            cbxCliente.Checked = true;
            cbxFornecedor.Checked = true;
            cbxTipoDePagamento.Checked = true;
            cbxUsuario.Checked = true;
            //Permissões Consulta Cadastro
            cbxConsultaCadastro.Checked = true;
            cbxConsultaCategoria.Checked = true;
            cbxConsultaSubCategoria.Checked = true;
            cbxConsultaUnidadeMedida.Checked = true;
            cbxConsultaProduto.Checked = true;
            cbxConsultaCliente.Checked = true;
            cbxConsultaFornecedor.Checked = true;
            cbxConsultaTipoPagamento.Checked = true;
            cbxConsultaCompra.Checked = true;
            cbxConsultaVenda.Checked = true;
            cbxConsultaUsuario.Checked = true;
            //Permissões Movimentação
            cbxMovimentacao.Checked = true;
            cbxCompra.Checked = true;
            cbxVenda.Checked = true;
            cbxPagamentoCompra.Checked = true;
            cbxPagamentoVenda.Checked = true;
            //Permissão Relatório
            cbxRelatorio.Checked = true;
            //Permissão Sobre
            cbxSobre.Checked = true;
            //Permissões Ferramentas
            cbxFerramentas.Checked = true;
            cbxConfiguracaoBanco.Checked = true;
            cbxBackup.Checked = true;
            cbxCalculadora.Checked = true;
            cbxExplorer.Checked = true;
            cbxBlocoNotas.Checked = true;
            cbxCmd.Checked = true;
            //Permissões Botões Padrão
            cbxBotaoLocalizar.Checked = true;
            cbxBotaoExcluir.Checked = true;
            cbxBotaoSalvar.Checked = true;
            cbxBotaoCancelar.Checked = true;
            //Permissões Botões Compra
            cbxBotaoCompraSalvar.Checked = true;
            cbxBotaoCompraCancelar.Checked = true;
            //Permissões Botões Venda
            cbxBotaoVendaSalvar.Checked = true;
            cbxBotaoVendaCancelar.Checked = true;
        }
        private void DesmarcarTodasPermissoes()
        {
            cbxSelecioneTodas.Checked = false;
            //Permissões Cadastro
            cbxCadastro.Checked = false;
            cbxCategoria.Checked = false;
            cbxSubCategoria.Checked = false;
            cbxUnidadeDeMedida.Checked = false;
            cbxProduto.Checked = false;
            cbxCliente.Checked = false;
            cbxFornecedor.Checked = false;
            cbxTipoDePagamento.Checked = false;
            cbxUsuario.Checked = false;
            //Permissões Consulta Cadastro
            cbxConsultaCadastro.Checked = false;
            cbxConsultaCategoria.Checked = false;
            cbxConsultaSubCategoria.Checked = false;
            cbxConsultaUnidadeMedida.Checked = false;
            cbxConsultaProduto.Checked = false;
            cbxConsultaCliente.Checked = false;
            cbxConsultaFornecedor.Checked = false;
            cbxConsultaTipoPagamento.Checked = false;
            cbxConsultaCompra.Checked = false;
            cbxConsultaVenda.Checked = false;
            cbxConsultaUsuario.Checked = false;
            //Permissões Movimentação
            cbxMovimentacao.Checked = false;
            cbxCompra.Checked = false;
            cbxVenda.Checked = false;
            cbxPagamentoCompra.Checked = false;
            cbxPagamentoVenda.Checked = false;
            //Permissão Relatório
            cbxRelatorio.Checked = false;
            //Permissão Sobre
            cbxSobre.Checked = false;
            //Permissões Ferramentas
            cbxFerramentas.Checked = false;
            cbxConfiguracaoBanco.Checked = false;
            cbxBackup.Checked = false;
            cbxCalculadora.Checked = false;
            cbxExplorer.Checked = false;
            cbxBlocoNotas.Checked = false;
            cbxCmd.Checked = false;
            //Permissões Botões Padrão
            cbxBotaoLocalizar.Checked = false;
            cbxBotaoExcluir.Checked = false;
            cbxBotaoSalvar.Checked = false;
            cbxBotaoCancelar.Checked = false;
            //Permissões Botões Compra
            cbxBotaoCompraSalvar.Checked = false;
            cbxBotaoCompraCancelar.Checked = false;
            //Permissões Botões Venda
            cbxBotaoVendaSalvar.Checked = false;
            cbxBotaoVendaCancelar.Checked = false;
        }
        private DataTable CarregaPermissao(int usucod)
        {
            DataTable itensPermissao = new DataTable();
            itensPermissao.Columns.Add("usu_cod");
            itensPermissao.Columns.Add("usu_per");
            //Cadastro
            if (cbxCadastro.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxCadastro.Name);
            }
            if (cbxCategoria.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxCategoria.Name);
            }
            if (cbxSubCategoria.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxSubCategoria.Name);
            }
            if (cbxUnidadeDeMedida.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxUnidadeDeMedida.Name);
            }
            if (cbxProduto.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxProduto.Name);
            }
            if (cbxCliente.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxCliente.Name);
            }
            if (cbxFornecedor.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxFornecedor.Name);
            }
            if (cbxTipoDePagamento.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxTipoDePagamento.Name);
            }
            if (cbxUsuario.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxUsuario.Name);
            }
            //Consulta
            if (cbxConsultaCadastro.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaCadastro.Name);
            }
            if (cbxConsultaCategoria.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaCategoria.Name);
            }
            if (cbxConsultaSubCategoria.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaSubCategoria.Name);
            }
            if (cbxConsultaUnidadeMedida.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaUnidadeMedida.Name);
            }
            if (cbxConsultaProduto.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaProduto.Name);
            }
            if (cbxConsultaCliente.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaCliente.Name); ;
            }
            if (cbxConsultaFornecedor.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaFornecedor.Name);
            }
            if (cbxConsultaTipoPagamento.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaTipoPagamento.Name);
            }
            if (cbxConsultaCompra.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaCompra.Name);
            }
            if (cbxConsultaVenda.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaVenda.Name);
            }
            if (cbxConsultaUsuario.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConsultaUsuario.Name);
            }
            //Movimentação
            if (cbxMovimentacao.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxMovimentacao.Name);
            }
            if (cbxCompra.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxCompra.Name);
            }
            if (cbxVenda.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxVenda.Name);
            }
            if (cbxPagamentoCompra.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxPagamentoCompra.Name);
            }
            if (cbxPagamentoVenda.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxPagamentoVenda.Name);
            }
            //Relatório
            if (cbxRelatorio.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxRelatorio.Name);
            }
            //Sobre
            if (cbxSobre.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxSobre.Name);
            }
            //Ferramentas
            if (cbxFerramentas.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxFerramentas.Name);
            }
            if (cbxConfiguracaoBanco.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxConfiguracaoBanco.Name);
            }
            if (cbxBackup.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBackup.Name);
            }
            if (cbxCalculadora.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxCalculadora.Name);
            }
            if (cbxExplorer.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxExplorer.Name);
            }
            if (cbxBlocoNotas.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBlocoNotas.Name);
            }
            if (cbxCmd.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxCmd.Name);
            }
            //Botões Principais
            if (cbxBotaoLocalizar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoLocalizar.Name);
            }
            if (cbxBotaoExcluir.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoExcluir.Name);
            }
            if (cbxBotaoSalvar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoSalvar.Name);
            }
            if (cbxBotaoCancelar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoCancelar.Name);
            }
            //Botões Compra
            if (cbxBotaoCompraSalvar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoCompraSalvar.Name);
            }
            if (cbxBotaoCompraCancelar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoCompraCancelar.Name);
            }
            //Botões Venda
            if (cbxBotaoVendaSalvar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoVendaSalvar.Name);
            }
            if (cbxBotaoVendaCancelar.Checked)
            {
                itensPermissao.Rows.Add(usucod, cbxBotaoVendaCancelar.Name);
            }
            return itensPermissao;
        }
        private void CadastraPermissao(int usucod)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLControlePermissao bll = new BLLControlePermissao(cx);
            bll.Inserir(CarregaPermissao(usucod), usucod);
        }
        private void PreenchePermissoes(DataTable tabela)
        {
            DesmarcarTodasPermissoes();
            //Cadastro
            if (tabela.Select("PERMISSAO = '" + cbxCadastro.Name + "'").Count() > 0)
            {
                cbxCadastro.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxCategoria.Name + "'").Count() > 0)
            {
                cbxCategoria.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxSubCategoria.Name + "'").Count() > 0)
            {
                cbxSubCategoria.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxUnidadeDeMedida.Name + "'").Count() > 0)
            {
                cbxUnidadeDeMedida.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxProduto.Name + "'").Count() > 0)
            {
                cbxProduto.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxCliente.Name + "'").Count() > 0)
            {
                cbxCliente.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxFornecedor.Name + "'").Count() > 0)
            {
                cbxFornecedor.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxTipoDePagamento.Name + "'").Count() > 0)
            {
                cbxTipoDePagamento.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxUsuario.Name + "'").Count() > 0)
            {
                cbxUsuario.Checked = true;
            }
            //Consulta
            if (tabela.Select("PERMISSAO = '" + cbxConsultaCadastro.Name + "'").Count() > 0)
            {
                cbxConsultaCadastro.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaCategoria.Name + "'").Count() > 0)
            {
                cbxConsultaCategoria.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaSubCategoria.Name + "'").Count() > 0)
            {
                cbxConsultaSubCategoria.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaUnidadeMedida.Name + "'").Count() > 0)
            {
                cbxConsultaUnidadeMedida.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaProduto.Name + "'").Count() > 0)
            {
                cbxConsultaProduto.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaCliente.Name + "'").Count() > 0)
            {
                cbxConsultaCliente.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaFornecedor.Name + "'").Count() > 0)
            {
                cbxConsultaFornecedor.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaTipoPagamento.Name + "'").Count() > 0)
            {
                cbxConsultaTipoPagamento.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaCompra.Name + "'").Count() > 0)
            {
                cbxConsultaCompra.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaVenda.Name + "'").Count() > 0)
            {
                cbxConsultaVenda.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConsultaUsuario.Name + "'").Count() > 0)
            {
                cbxConsultaUsuario.Checked = true;
            }
            //Movimentação
            if (tabela.Select("PERMISSAO = '" + cbxMovimentacao.Name + "'").Count() > 0)
            {
                cbxMovimentacao.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxCompra.Name + "'").Count() > 0)
            {
                cbxCompra.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxVenda.Name + "'").Count() > 0)
            {
                cbxVenda.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxPagamentoCompra.Name + "'").Count() > 0)
            {
                cbxPagamentoCompra.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxPagamentoVenda.Name + "'").Count() > 0)
            {
                cbxPagamentoVenda.Checked = true;
            }
            //Relatório
            if (tabela.Select("PERMISSAO = '" + cbxRelatorio.Name + "'").Count() > 0)
            {
                cbxRelatorio.Checked = true;
            }
            //Sobre
            if (tabela.Select("PERMISSAO = '" + cbxSobre.Name + "'").Count() > 0)
            {
                cbxSobre.Checked = true;
            }
            //Ferramentas
            if (tabela.Select("PERMISSAO = '" + cbxFerramentas.Name + "'").Count() > 0)
            {
                cbxFerramentas.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxConfiguracaoBanco.Name + "'").Count() > 0)
            {
                cbxConfiguracaoBanco.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBackup.Name + "'").Count() > 0)
            {
                cbxBackup.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxCalculadora.Name + "'").Count() > 0)
            {
                cbxCalculadora.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxExplorer.Name + "'").Count() > 0)
            {
                cbxExplorer.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBlocoNotas.Name + "'").Count() > 0)
            {
                cbxBlocoNotas.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxCmd.Name + "'").Count() > 0)
            {
                cbxCmd.Checked = true;
            }
            //Botões Principais
            if (tabela.Select("PERMISSAO = '" + cbxBotaoLocalizar.Name + "'").Count() > 0)
            {
                cbxBotaoLocalizar.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBotaoExcluir.Name + "'").Count() > 0)
            {
                cbxBotaoExcluir.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBotaoSalvar.Name + "'").Count() > 0)
            {
                cbxBotaoSalvar.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBotaoCancelar.Name + "'").Count() > 0)
            {
                cbxBotaoCancelar.Checked = true;
            }
            //Botões Compra
            if (tabela.Select("PERMISSAO = '" + cbxBotaoCompraSalvar.Name + "'").Count() > 0)
            {
                cbxBotaoCompraSalvar.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBotaoCompraCancelar.Name + "'").Count() > 0)
            {
                cbxBotaoCompraCancelar.Checked = true;
            }
            //Botões Venda
            if (tabela.Select("PERMISSAO = '" + cbxBotaoVendaSalvar.Name + "'").Count() > 0)
            {
                cbxBotaoVendaSalvar.Checked = true;
            }
            if (tabela.Select("PERMISSAO = '" + cbxBotaoVendaCancelar.Name + "'").Count() > 0)
            {
                cbxBotaoVendaCancelar.Checked = true;
            }
        }
        public void LocalizarUsuário()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUsuario bll = new BLLUsuario(cx);
            BLLControlePermissao cbll = new BLLControlePermissao(cx);
            ModeloUsuario modelo = bll.CarregaModeloUsuario(codigo);
            PreencheCampos(modelo);
            DataTable tabela = new DataTable();
            tabela = cbll.Localizar(codigo);
            PreenchePermissoes(tabela);
            alteraBotoes();
        }
        //private void AtulizaMenu()
        //{
        //    principal.Login(txtLogin.Text, txtSenha.Text);
        //    principal.Refresh();
        //}
        private void CombinaEndereco(string campo)
        {
            carregaComboBox = false;
            //Esta condição é executada quando digitar o cep
            if (campo == "estadocep")
            {
                LimpaEndereco(campo);
                cbxEstado.DataSource = BuscaEndereco.CombinarSiglaEstado(cbxSgl.Text);
                cbxEstado.ValueMember = "CODIGOESTADO";
                cbxEstado.DisplayMember = "ESTADO";
            }
            //Esta condição é executada quando digitar o cep e não for encontrado no sistema dos correios
            if (campo == "cep")
            {
                LimpaEndereco(campo);
                string cep = mktCep.Text.Replace("-", "");
                cbxSgl.DataSource = BuscaEndereco.CombinarCepSigla(cep);
                cbxSgl.ValueMember = "CODIGOSIGLA";
                cbxSgl.DisplayMember = "SIGLA";
                if (cbxSgl.Text == "")
                {
                    CombinaEndereco("load");
                }
                else
                {
                    campo = "sigla";
                }
            }
            //Esta condição é executada quando alterar a sigla
            if (campo == "load")
            {
                cbxSgl.SelectedIndex = 24;//Seleciona o estado de são paulo
                cbxEstado.DataSource = BuscaEndereco.CombinarSiglaEstado(cbxSgl.Text);
                cbxEstado.ValueMember = "CODIGOESTADO";
                cbxEstado.DisplayMember = "ESTADO";
                cbxCidade.DataSource = BuscaEndereco.CombinarEstadoCidade(cbxEstado.Text);
                cbxCidade.ValueMember = "CODIGOCIDADE";
                cbxCidade.DisplayMember = "CIDADE";
                cbxCidade.SelectedIndex = 564;//Seleciona a cidade de são paulo
                campo = "cidade";
                cbxLogradouro.Focus();

            }
            if (campo == "sigla")
            {
                LimpaEndereco(campo);
                cbxEstado.DataSource = BuscaEndereco.CombinarSiglaEstado(cbxSgl.Text);
                cbxEstado.ValueMember = "CODIGOESTADO";
                cbxEstado.DisplayMember = "ESTADO";
                cbxCidade.DataSource = BuscaEndereco.CombinarEstadoCidade(cbxEstado.Text);
                cbxCidade.ValueMember = "CODIGOCIDADE";
                cbxCidade.DisplayMember = "CIDADE";
                campo = "cidade";
            }
            if (campo == "estado")
            {
                LimpaEndereco(campo);
                cbxCidade.DataSource = BuscaEndereco.CombinarEstadoCidade(cbxEstado.Text);
                cbxCidade.ValueMember = "CODIGOCIDADE";
                cbxCidade.DisplayMember = "CIDADE";
                campo = "cidade";
            }
            //Esta condição é executada quando alterar a cidade
            if (campo == "cidade")
            {
                LimpaEndereco(campo);
                cbxBairro.DataSource = BuscaEndereco.CombinarCidadeBairro(cbxCidade.Text);
                cbxBairro.ValueMember = "CODIGOBAIRRO";
                cbxBairro.DisplayMember = "BAIRRO";
                campo = "bairro";
            }
            if (campo == "bairro")
            {
                LimpaEndereco(campo);
                cbxLogradouro.DataSource = BuscaEndereco.CombinarBairroLogradouro(cbxBairro.Text);
                cbxLogradouro.ValueMember = "CODIGOLOGRADOURO";
                cbxLogradouro.DisplayMember = "LOGRADOURO";
            }
            carregaComboBox = true;
        }
        private void CarregaCombobox()
        {
            carregaComboBox = false;
            //Carrega a sigla
            cbxSgl.DataSource = BuscaEndereco.ConsultarEstadoSgl();
            cbxSgl.ValueMember = "CODIGO";
            cbxSgl.DisplayMember = "SIGLA";
            //CombinaEndereco
            CombinaEndereco("load");
            //Adiciona o auto completar
            cbxEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxEstado.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxSgl.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxSgl.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCidade.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxCidade.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxBairro.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxBairro.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxLogradouro.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxLogradouro.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ComboBoxFoco(string campo)
        {
            if (campo == "sigla")
            {
                if (cbxEstado.Text == "")
                {
                    cbxEstado.Focus();
                }
                else if (cbxCidade.Text == "")
                {
                    cbxCidade.Focus();
                }
                else if (cbxBairro.Text == "")
                {
                    cbxBairro.Focus();
                }
                else if (cbxLogradouro.Text == "")
                {
                    cbxLogradouro.Focus();
                }
                else
                {
                    txtNumero.Focus();
                }
            }
            if (campo == "estado")
            {
                if (cbxCidade.Text == "")
                {
                    cbxCidade.Focus();
                }
                else if (cbxBairro.Text == "")
                {
                    cbxBairro.Focus();
                }
                else if (cbxLogradouro.Text == "")
                {
                    cbxLogradouro.Focus();
                }
                else
                {
                    txtNumero.Focus();
                }
            }
            if (campo == "cidade")
            {
                if (cbxBairro.Text == "")
                {
                    cbxBairro.Focus();
                }
                else if (cbxLogradouro.Text == "")
                {
                    cbxLogradouro.Focus();
                }
                else
                {
                    txtNumero.Focus();
                }
            }
            if (campo == "bairro")
            {
                if (cbxLogradouro.Text == "")
                {
                    cbxLogradouro.Focus();
                }
                else
                {
                    txtNumero.Focus();
                }
            }
            if (campo == "logradouro")
            {
                txtNumero.Focus();
            }
        }
        #endregion

        #region "Marca CheckBox"
        private void cbxSelecioneTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelecioneTodas.Checked)
            {
                MarcarTodasPermissoes();
            }
            else
            {
                DesmarcarTodasPermissoes();
            }
        }
        private void MarcaCadastro()
        {
            cbxCadastro.Checked = (cbxCategoria.Checked || cbxSubCategoria.Checked || cbxUnidadeDeMedida.Checked || cbxProduto.Checked || cbxCliente.Checked || cbxFornecedor.Checked || cbxTipoDePagamento.Checked || cbxUsuario.Checked) ? true : false;
        }
        private void cbxCategoria_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxSubCategoria_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxUnidadeDeMedida_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxProduto_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxCliente_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxTipoDePagamento_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void cbxUsuario_CheckedChanged(object sender, EventArgs e)
        {
            MarcaCadastro();
        }
        private void MarcaConsultaCadastro()
        {
            cbxConsultaCadastro.Checked = (cbxConsultaCategoria.Checked || cbxConsultaSubCategoria.Checked || cbxConsultaUnidadeMedida.Checked || cbxConsultaProduto.Checked || cbxConsultaCliente.Checked || cbxConsultaFornecedor.Checked || cbxConsultaTipoPagamento.Checked || cbxConsultaCompra.Checked || cbxConsultaVenda.Checked || cbxConsultaUsuario.Checked) ? true : false;
        }
        private void cbxConsultaCategoria_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaSubCategoria_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaUnidadeMedida_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaProduto_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaCliente_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaTipoPagamento_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaCompra_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaVenda_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void cbxConsultaUsuario_CheckedChanged(object sender, EventArgs e)
        {
            MarcaConsultaCadastro();
        }
        private void MarcaMovimentacao()
        {
            cbxMovimentacao.Checked = (cbxCompra.Checked || cbxVenda.Checked || cbxPagamentoCompra.Checked || cbxPagamentoVenda.Checked) ? true : false;
        }
        private void cbxCompra_CheckedChanged(object sender, EventArgs e)
        {
            MarcaMovimentacao();
        }
        private void cbxVenda_CheckedChanged(object sender, EventArgs e)
        {
            MarcaMovimentacao();
        }
        private void cbxPagamentoCompra_CheckedChanged(object sender, EventArgs e)
        {
            MarcaMovimentacao();
        }
        private void cbxPagamentoVenda_CheckedChanged(object sender, EventArgs e)
        {
            MarcaMovimentacao();
        }
        private void MarcaFerramentas()
        {
            cbxFerramentas.Checked = (cbxConfiguracaoBanco.Checked || cbxBackup.Checked || cbxCalculadora.Checked || cbxExplorer.Checked || cbxBlocoNotas.Checked || cbxCmd.Checked) ? true : false;
        }
        private void cbxConfiguracaoBanco_CheckedChanged(object sender, EventArgs e)
        {
            MarcaFerramentas();
        }
        private void cbxBackup_CheckedChanged(object sender, EventArgs e)
        {
            MarcaFerramentas();
        }
        private void cbxCalculadora_CheckedChanged(object sender, EventArgs e)
        {
            MarcaFerramentas();
        }
        private void cbxExplorer_CheckedChanged(object sender, EventArgs e)
        {
            MarcaFerramentas();
        }
        private void cbxBlocoNotas_CheckedChanged(object sender, EventArgs e)
        {
            MarcaFerramentas();
        }
        private void cbxCmd_CheckedChanged(object sender, EventArgs e)
        {
            MarcaFerramentas();
        }
        #endregion

        #region "Otimização Formulário"
        private void txtLogin_Leave(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUsuario bll = new BLLUsuario(cx);
            if (!bll.LoginDisponivel(txtLogin.Text))
            {
                Mensagem("LOGIN INDISPONÍVEL, DIGITE OUTRO ", Color.Red);
                txtLogin.SelectAll();
                txtLogin.Focus();
            }
        }
        private void mktCpfCnpj_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktCpfCnpj.Text.Trim().Length == 14)
            {
                mktRgIe.Focus();
            }
        }
        private void mktRgIe_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktRgIe.Text.Trim().Length == 12)
            {
                mktCep.Focus();
            }
        }
        private void mktCep_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktCep.Text.Trim().Length == 9)
            {
                LimpaEndereco("cep");
                if (BuscaEndereco.verificaCEP(mktCep.Text))
                {
                    cbxSgl.Text = BuscaEndereco.estado.ToUpper();
                    cbxCidade.Text = BuscaEndereco.cidade.ToUpper();
                    cbxBairro.Text = BuscaEndereco.bairro.ToUpper();
                    cbxLogradouro.Text = BuscaEndereco.endereco.ToUpper();
                    CombinaEndereco("estadocep");
                    txtNumero.Focus();
                }

                if (cbxSgl.Text == "")
                {
                    CarregaCombobox();
                }
            }
        }
        private void chkSN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSN.Checked)
            {
                txtNumero.Text = "S/N";
            }
            else
            {
                txtNumero.Text = "";
                txtNumero.Focus();
            }
        }
        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            chkSN.Checked = false;
        }
        private void mktTelefone_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktTelefone.Text.Trim().Length == 13)
            {
                mktCelular.Focus();
            }
        }
        private void mktCelular_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktCelular.Text.Trim().Length == 14)
            {
                txtLogin.Focus();
            }
        }
        private void cbxSgl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregaComboBox)
            {
                CombinaEndereco("sigla");
                ComboBoxFoco("sigla");
            }       
        }
        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregaComboBox)
            {
                CombinaEndereco("estado");
                ComboBoxFoco("estado");
            }       
        }
        private void cbxCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregaComboBox)
            {
                CombinaEndereco("cidade");
                ComboBoxFoco("cidade");
            }       
        }
        private void cbxBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregaComboBox)
            {
                CombinaEndereco("bairro");
                ComboBoxFoco("bairro");
            }
        }
        #endregion
    }
}
