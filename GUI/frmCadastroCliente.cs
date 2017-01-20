using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Modelo;
using DAL;
using Ferramentas;

namespace GUI
{
    public partial class frmCadastroCliente : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        private bool carregaComboBox;
        #endregion

        #region "Eventos"
        public frmCadastroCliente()
        {
            InitializeComponent();
        }
        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            CarregaCombobox();
            if (codigo != 0)
            {
                LocalizarCliente();
                codigo = 0;
            }
            alteraBotoes();
            txtNome.Focus();
        }
        public void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCliente f = new frmConsultaCliente();
            Close();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja realmente excluir o registro? ", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                try
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                    BLLCliente bll = new BLLCliente(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    LimpaTela();
                    alteraBotoes();
                    txtNome.Focus();
                    Mensagem("CLIENTE EXCLUIDO ", Color.Blue);
                }
                catch (Exception erro)
                {
                    Erro("ERRO AO EXCLUIR O CLIENTE " + erro.Message);
                    alteraBotoes();
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Carrega o modelo
                ModeloCliente modelo = new ModeloCliente()
                {
                    cli_nome = txtNome.Text,
                    cli_rsocial = txtRazaoSocial.Text,
                    cli_cpfcnpj = mktCnpj.Text,
                    cli_rgie = mktIe.Text,
                    cli_cep = mktCep.Text,
                    cli_sgl = cbxSgl.Text,
                    cli_estado = cbxEstado.Text,
                    cli_cidade = cbxCidade.Text,
                    cli_bairro = cbxBairro.Text,
                    cli_logradouro = cbxLogradouro.Text,
                    cli_numero = txtNumero.Text,
                    cli_complemento = txtComplemento.Text,
                    cli_email = txtEmail.Text,
                    cli_telefone = mktTelefone.Text,
                    cli_celular = mktCelular.Text
                };
                if (rdbFisica.Checked)
                {
                    modelo.cli_tipo = "FISICA";
                }
                else
                {
                    modelo.cli_tipo = "JURIDICA";
                }
                DALConexao conexao = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLCliente bll = new BLLCliente(conexao);
                if (txtCodigo.Text == "")
                {
                    bll.Inserir(modelo);
                    Mensagem("CLIENTE INSERIDO, CÓDIGO: " + modelo.cli_cod, Color.Blue);
                }
                else
                {
                    modelo.cli_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    Mensagem("CLIENTE ALTERADO ", Color.Blue);
                }
                alteraBotoes();
                LimpaTela();
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
            rdbFisica.Checked = true;
            txtNome.Clear();
            txtRazaoSocial.Clear();
            mktCnpj.Clear();
            mktIe.Clear();
            mktCep.Clear();
            txtEmail.Clear();
            mktTelefone.Clear();
            mktCelular.Clear();
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
        private void PreencheCampos(ModeloCliente modelo)
        {
            txtCodigo.Text = modelo.cli_cod.ToString();
            txtNome.Text = modelo.cli_nome;
            txtRazaoSocial.Text = modelo.cli_rsocial;
            mktCnpj.Text = modelo.cli_cpfcnpj;
            mktIe.Text = modelo.cli_rgie;
            mktCep.Text = modelo.cli_cep;
            cbxSgl.Text = modelo.cli_sgl;
            cbxEstado.Text = modelo.cli_estado;
            cbxCidade.Text = modelo.cli_cidade;
            cbxBairro.Text = modelo.cli_bairro;
            cbxLogradouro.Text = modelo.cli_logradouro;
            txtComplemento.Text = modelo.cli_complemento;
            txtNumero.Text = modelo.cli_numero;
            txtEmail.Text = modelo.cli_email;
            mktTelefone.Text = modelo.cli_telefone;
            mktCelular.Text = modelo.cli_celular;
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
                    Mensagem("DIGITE O NOME DO CLIENTE", Color.Red);
                    break;
                case "rsocial":
                    txtRazaoSocial.Focus();
                    Mensagem("DIGITE A RAZÃO SOCIAL DO CLIENTE", Color.Red);
                    break;
                case "cpf":
                    mktCnpj.Focus();
                    Mensagem("CPF INVÁLIDO", Color.Red);
                    break;
                case "cnpj":
                    mktCnpj.Focus();
                    Mensagem("CNPJ INVÁLIDO", Color.Red);
                    break;
                case "rg":
                    mktIe.Focus();
                    Mensagem("INSIRA O RG DO CLIENTE", Color.Red);
                    break;
                case "ie":
                    mktIe.Focus();
                    Mensagem("INSIRA A INSCRIÇÃO ESTADUAL DO CLIENTE", Color.Red);
                    break;
                case "cep":
                    mktCep.Focus();
                    Mensagem("DIGITE O CEP DO CLIENTE", Color.Red);
                    break;
                case "sgl":
                    cbxSgl.Focus();
                    Mensagem("DIGITE A SIGLA", Color.Red);
                    break;
                case "estado":
                    cbxEstado.Focus();
                    Mensagem("DIGITE O ESTADO", Color.Red);
                    break;
                case "cidade":
                    cbxCidade.Focus();
                    Mensagem("DIGITE A CIDADE", Color.Red);
                    break;
                case "bairro":
                    cbxBairro.Focus();
                    Mensagem("DIGITE O BAIRRO", Color.Red);
                    break;
                case "endereco":
                    cbxLogradouro.Focus();
                    Mensagem("DIGITE O ENDEREÇO", Color.Red);
                    break;
                case "numero":
                    txtNumero.Focus();
                    Mensagem("DIGITE O NUMERO DO ENDEREÇO", Color.Red);
                    break;
                case "complemento":
                    txtComplemento.Focus();
                    Mensagem("DIGITE O COMPLEMENTO DO ENDEREÇO", Color.Red);
                    break;
                case "email":
                    txtEmail.Focus();
                    Mensagem("E-MAIL INVÁLIDO", Color.Red);
                    break;
                case "telefone":
                    mktTelefone.Focus();
                    Mensagem("DIGITE O TELEFONE DO CLIENTE", Color.Red);
                    break;
                case "celular":
                    mktCelular.Focus();
                    Mensagem("DIGITE O CELULAR DO CLIENTE", Color.Red);
                    break;
                default:
                    Erro("ERRO AO INSERIR OU ALTERAR O CLIENTE " + erro);
                    break;
            }
        }
        public void LocalizarCliente()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCliente bll = new BLLCliente(cx);
            ModeloCliente modelo = bll.CarregaModeloCliente(codigo);
            if (modelo.cli_tipo == "JURIDICA")
            {
                rdbJuridica.Checked = true;
            }
            PreencheCampos(modelo);
            alteraBotoes();
        }
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
        private void passarProximoCampoCpfCnpj()
        {
            if (mktCnpj.Text.Trim().Length == 14 && lblCpfCnpj.Text == "CPF")
            {
                mktIe.Focus();
            }
            if (mktCnpj.Text.Trim().Length == 18 && lblCpfCnpj.Text == "CNPJ")
            {
                mktIe.Focus();
            }
        }
        #endregion

        #region "Otimização"
        private void rdbFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFisica.Checked)
            {
                lblRazaoSocial.Visible = false;
                txtRazaoSocial.Visible = false;
                lblCpfCnpj.Text = "CPF";
                lblRgIe.Text = "RG";
                mktCnpj.Size = new System.Drawing.Size(83, 20);
                mktIe.Size = new System.Drawing.Size(71, 20);
                mktCnpj.Mask = "999.999.999-99";
                mktIe.Mask = "99.999.999-9";
            }
            else
            {
                lblRazaoSocial.Visible = true;
                txtRazaoSocial.Visible = true;
                lblCpfCnpj.Text = "CNPJ";
                lblRgIe.Text = "IE";
                mktCnpj.Size = new System.Drawing.Size(105, 20);
                mktIe.Size = new System.Drawing.Size(88, 20);
                mktCnpj.Mask = "99.999.999/9999-99";
                mktIe.Mask = "999.999.999.999";
            }
            mktCnpj.Clear();
        }
        private void mktCnpj_KeyUp(object sender, KeyEventArgs e)
        {
            passarProximoCampoCpfCnpj();
        }
        private void mktIe_KeyUp(object sender, KeyEventArgs e)
        {
            if ((lblRgIe.Text == "RG" && mktIe.Text.Trim().Length == 12) || (lblRgIe.Text == "IE" && mktIe.Text.Trim().Length == 15))
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
        private void mktTelefone_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktTelefone.Text.Trim().Length == 13)
            {
                mktCelular.Focus();
            }
        }
        #endregion
    }
}
