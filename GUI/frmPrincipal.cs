using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using DAL;
using System.Data.SqlClient;
using BLL;
using Modelo;

namespace GUI
{
    public partial class frmPrincipal : Form
    {
        #region "Menus"
        private void mnuCategoria_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuSubCategoria_Click(object sender, EventArgs e)
        {
            frmCadastroSubCategoria f = new frmCadastroSubCategoria();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuUnidadeMedida_Click(object sender, EventArgs e)
        {
            frmCadastroUnidadeMedida f = new frmCadastroUnidadeMedida();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuProduto_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuCliente_Click(object sender, EventArgs e)
        {
            frmCadastroCliente f = new frmCadastroCliente();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuFornecedor_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedor f = new frmCadastroFornecedor();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuTipoPagamento_Click(object sender, EventArgs e)
        {
            frmCadastroTipoPagamento f = new frmCadastroTipoPagamento();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuUsuario_Click(object sender, EventArgs e)
        {
            //frmCadastroUsuario f = new frmCadastroUsuario(this);
            frmCadastroUsuario f = new frmCadastroUsuario();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaCategoria_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaSubCategoria_Click(object sender, EventArgs e)
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaUnidadeMedida_Click(object sender, EventArgs e)
        {
            frmConsultaUnidadeMedida f = new frmConsultaUnidadeMedida();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaProduto_Click(object sender, EventArgs e)
        {
            frmConsultaProduto f = new frmConsultaProduto();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaCliente_Click(object sender, EventArgs e)
        {
            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaFornecedor_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaTipoPagamento_Click(object sender, EventArgs e)
        {
            frmConsultaTipoPagamento f = new frmConsultaTipoPagamento();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaCompra_Click(object sender, EventArgs e)
        {
            frmConsultaCompra f = new frmConsultaCompra();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuConsultaVenda_Click(object sender, EventArgs e)
        {
            //frmConsultaVenda f = new frmConsultaVenda();
            //f.ShowDialog();
            //f.Dispose();
        }
        private void mnuConsultaUsuario_Click(object sender, EventArgs e)
        {
            //frmConsultaUsuário f = new frmConsultaUsuário(this);
            frmConsultaUsuário f = new frmConsultaUsuário();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuCompra_Click(object sender, EventArgs e)
        {
            frmMovimentacaoCompra f = new frmMovimentacaoCompra();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuVenda_Click(object sender, EventArgs e)
        {

        }
        private void mnuPagamentoCompra_Click(object sender, EventArgs e)
        {
            frmPagamentoCompra f = new frmPagamentoCompra();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuPagamentoVenda_Click(object sender, EventArgs e)
        {

        }
        private void mnuConfiguracaoBanco_Click(object sender, EventArgs e)
        {
            frmConfiguracaoBancoDados f = new frmConfiguracaoBancoDados();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuBackup_Click(object sender, EventArgs e)
        {
            frmBackupBancoDeDados f = new frmBackupBancoDeDados();
            f.ShowDialog();
            f.Dispose();
        }
        private void mnuCalculadora_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }
        private void mnuExplorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer");
        }
        private void mnuBlocoNotas_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }
        private void mnuCmd_Click(object sender, EventArgs e)
        {
            Process.Start("cmd");
        }
        private void mnuSobre_Click(object sender, EventArgs e)
        {
            frmSobre f = new frmSobre();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region "Eventos"
        public frmPrincipal()
        {
            InitializeComponent();
        }
        public void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                //Verifica a conexão com o banco
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                DadosDaConexao.servidor = arquivo.ReadLine();
                DadosDaConexao.banco = arquivo.ReadLine();
                DadosDaConexao.usuario = arquivo.ReadLine();
                DadosDaConexao.senha = arquivo.ReadLine();
                arquivo.Close();
                //Testar a conexão
                SqlConnection conexao = new SqlConnection(DadosDaConexao.StringDeConexão);
                conexao.Open();
                conexao.Close();
                txtLogin.Focus();
                Login(txtLogin.Text, txtSenha.Text);
                mnuCadastro.Visible = true;
                mnuUsuario.Visible = true;
            }
            catch (SqlException errob)
            {
                MessageBox.Show("Erro ao se conectar no banco de dados \n" + "Acesse as configurações do banco de dados e informe os parâmetros de conexão \n" + errob.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message); ;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(txtLogin.Text, txtSenha.Text);
        }
        private void lklLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LimpaTela();
            DesabilitaControles();
        }
        #endregion

        #region "Funçoes"
        private void HabilitaControles()
        {
            //Cadastro
            mnuCadastro.Visible = true;
            mnuCategoria.Visible = true;
            mnuSubCategoria.Visible = true;
            mnuUnidadeMedida.Visible = true;
            mnuProduto.Visible = true;
            mnuCliente.Visible = true;
            mnuFornecedor.Visible = true;
            mnuTipoPagamento.Visible = true;
            mnuUsuario.Visible = true;
            //Consulta
            mnuConsulta.Visible = true;
            mnuConsultaCategoria.Visible = true;
            mnuConsultaSubCategoria.Visible = true;
            mnuConsultaUnidadeMedida.Visible = true;
            mnuConsultaProduto.Visible = true;
            mnuConsultaCliente.Visible = true;
            mnuConsultaFornecedor.Visible = true;
            mnuConsultaTipoPagamento.Visible = true;
            mnuConsultaCompra.Visible = true;
            mnuConsultaVenda.Visible = true;
            mnuConsultaUsuario.Visible = true;
            //Movimentação
            mnuMovimentacao.Visible = true;
            mnuCompra.Visible = true;
            mnuVenda.Visible = true;
            mnuPagamentoCompra.Visible = true;
            mnuPagamentoVenda.Visible = true;
            //Relatório
            mnuRelatorio.Visible = true;
            //Ferramentas
            mnuFerramentas.Visible = true;
            mnuConfiguracaoBanco.Visible = true;
            mnuBackup.Visible = true;
            mnuCalculadora.Visible = true;
            mnuExplorer.Visible = true;
            mnuBlocoNotas.Visible = true;
            mnuCmd.Visible = true;
            //Sobre
            mnuSobre.Visible = true;
        }
        private void DesabilitaControles()
        {
            //Cadastro
            mnuCadastro.Visible = false;
            mnuCategoria.Visible = false;
            mnuSubCategoria.Visible = false;
            mnuUnidadeMedida.Visible = false;
            mnuProduto.Visible = false;
            mnuCliente.Visible = false;
            mnuFornecedor.Visible = false;
            mnuTipoPagamento.Visible = false;
            mnuUsuario.Visible = false;
            //Consulta
            mnuConsulta.Visible = false;
            mnuConsultaCategoria.Visible = false;
            mnuConsultaSubCategoria.Visible = false;
            mnuConsultaUnidadeMedida.Visible = false;
            mnuConsultaProduto.Visible = false;
            mnuConsultaCliente.Visible = false;
            mnuConsultaFornecedor.Visible = false;
            mnuConsultaTipoPagamento.Visible = false;
            mnuConsultaCompra.Visible = false;
            mnuConsultaVenda.Visible = false;
            mnuConsultaUsuario.Visible = false;
            //Movimentação
            mnuMovimentacao.Visible = false;
            mnuCompra.Visible = false;
            mnuVenda.Visible = false;
            mnuPagamentoCompra.Visible = false;
            mnuPagamentoVenda.Visible = false;
            //Relatório
            mnuRelatorio.Visible = false;
            //Ferramentas
            mnuFerramentas.Visible = false;
            mnuConfiguracaoBanco.Visible = false;
            mnuBackup.Visible = false;
            mnuCalculadora.Visible = false;
            mnuExplorer.Visible = false;
            mnuBlocoNotas.Visible = false;
            mnuCmd.Visible = false;
            //Sobre
            mnuSobre.Visible = false;
        }
        private void PermissoesUsuario()
        {
            DesabilitaControles();
            //Cadastro
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxCadastro'").Count() > 0)
            {
                mnuCadastro.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxCategoria'").Count() > 0)
            {
                mnuCategoria.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxSubCategoria'").Count() > 0)
            {
                mnuSubCategoria.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxUnidadeDeMedida'").Count() > 0)
            {
                mnuUnidadeMedida.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxProduto'").Count() > 0)
            {
                mnuProduto.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxCliente'").Count() > 0)
            {
                mnuCliente.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxFornecedor'").Count() > 0)
            {
                mnuFornecedor.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxTipoDePagamento'").Count() > 0)
            {
                mnuTipoPagamento.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxUsuario'").Count() > 0)
            {
                mnuUsuario.Visible = true;
            }
            //Consulta
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaCadastro'").Count() > 0)
            {
                mnuConsulta.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaCategoria'").Count() > 0)
            {
                mnuConsultaCategoria.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaSubCategoria'").Count() > 0)
            {
                mnuConsultaSubCategoria.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaUnidadeMedida'").Count() > 0)
            {
                mnuConsultaUnidadeMedida.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaProduto'").Count() > 0)
            {
                mnuConsultaProduto.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaCliente'").Count() > 0)
            {
                mnuConsultaCliente.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaFornecedor'").Count() > 0)
            {
                mnuConsultaFornecedor.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaTipoPagamento'").Count() > 0)
            {
                mnuConsultaTipoPagamento.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaCompra'").Count() > 0)
            {
                mnuConsultaCompra.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaVenda'").Count() > 0)
            {
                mnuConsultaVenda.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConsultaUsuario'").Count() > 0)
            {
                mnuConsultaUsuario.Visible = true;
            }
            //Movimentação
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxMovimentacao'").Count() > 0)
            {
                mnuMovimentacao.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxCompra'").Count() > 0)
            {
                mnuCompra.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxVenda'").Count() > 0)
            {
                mnuVenda.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxPagamentoCompra'").Count() > 0)
            {
                mnuPagamentoCompra.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxPagamentoVenda'").Count() > 0)
            {
                mnuPagamentoVenda.Visible = true;
            }
            //Relatório
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxRelatorio'").Count() > 0)
            {
                mnuRelatorio.Visible = true;
            }
            //Sobre
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxSobre'").Count() > 0)
            {
                mnuSobre.Visible = true;
            }
            //Ferramentas
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxFerramentas'").Count() > 0)
            {
                mnuFerramentas.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxConfiguracaoBanco'").Count() > 0)
            {
                mnuConfiguracaoBanco.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxBackup'").Count() > 0)
            {
                mnuBackup.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxCalculadora'").Count() > 0)
            {
                mnuCalculadora.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxExplorer'").Count() > 0)
            {
                mnuExplorer.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxBlocoNotas'").Count() > 0)
            {
                mnuBlocoNotas.Visible = true;
            }
            if (ModeloControlePermissao.per_permissoes.Select("PERMISSAO = 'cbxCmd'").Count() > 0)
            {
                mnuCmd.Visible = true;
            }
        }
        private void HabilitaBotaoLogin(KeyEventArgs e)
        {
            if ((txtLogin.Text.Trim().Length > 0) && (txtSenha.Text.Trim().Length > 4))
            {
                btnLogin.Enabled = true;
                if (e.KeyCode == Keys.Enter)
                {
                    Login(txtLogin.Text, txtSenha.Text);
                }
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }
        private void LimpaTela()
        {
            lklLogout.Visible = false;
            tssStatusLogin.Text = "";
            grbLogin.Visible = true;
            txtLogin.Clear();
            txtSenha.Clear();
            txtLogin.Focus();
            tssStatusLogin.Text = "";
        }
        public void Login(string login, string senha)
        {
            ModeloUsuario modelo = new ModeloUsuario();
            modelo.usu_login = login;
            modelo.usu_senha = senha;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUsuario bll = new BLLUsuario(cx);
            BLLControlePermissao cbll = new BLLControlePermissao(cx);
            bll.UsuarioLogar(modelo).ToString();
            if (modelo.usu_nome != "")
            {
                tssStatusLogin.Text = "USUÁRIO LOGADO: " + modelo.usu_nome;
                grbLogin.Visible = false;
                lklLogout.Visible = true;
                cbll.Localizar(modelo.usu_cod);
                PermissoesUsuario();
            }
            else
            {
                tssStatusLogin.Text = "USUÁRIO OU SENHA INCORRETO ";
                txtLogin.Focus();
                btnLogin.Enabled = false;
            }
        }
        #endregion

        #region "Otimização"
        private void txtLogin_KeyUp(object sender, KeyEventArgs e)
        {
            HabilitaBotaoLogin(e);
        }
        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            HabilitaBotaoLogin(e);
        }
        #endregion
    }
}





