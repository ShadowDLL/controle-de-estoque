using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;
using Ferramentas;

namespace GUI
{
    public partial class frmCadastroFornecedor : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        private bool carregaComboBox;
        #endregion

        #region "Eventos"
        public frmCadastroFornecedor()
        {
            InitializeComponent();
        }
        private void frmCadastroFornecedor_Load(object sender, EventArgs e)
        {
            CarregaCombobox();
            if (codigo != 0)
            {
                LocalizarFornecedor();
                codigo = 0;
            }
            alteraBotoes();
            txtNome.Focus();
        }
        public void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLFornecedor bll = new BLLFornecedor(cx);
                ModeloFornecedor modelo = bll.CarregaModeloFornecedor(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                frmConsultaFornecedor f = new frmConsultaFornecedor();
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
                    BLLFornecedor bll = new BLLFornecedor(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    LimpaTela();
                    alteraBotoes();
                    txtNome.Focus();
                    Mensagem("FORNECEDOR EXCLUIDO ", Color.Blue);
                }
                catch (Exception erro)
                {
                    Erro("ERRO AO EXCLUIR O FORNECEDOR " + erro.Message);
                    alteraBotoes();
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloFornecedor modelo = new ModeloFornecedor()
                {
                    for_nome = txtNome.Text,
                    for_rsocial = txtRazaoSocial.Text,
                    for_ie = mktIe.Text,
                    for_cnpj = mktCnpj.Text,
                    for_cep = mktCep.Text,
                    for_estado = cbxEstado.Text,
                    for_sgl = cbxSgl.Text,
                    for_cidade = cbxCidade.Text,
                    for_bairro = cbxBairro.Text,
                    for_logradouro = cbxLogradouro.Text,
                    for_numero = txtNumero.Text,
                    for_complemento = txtComplemento.Text,
                    for_email = txtEmail.Text,
                    for_telefone = mktTelefone.Text,
                    for_celular = mktCelular.Text
                };
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLFornecedor bll = new BLLFornecedor(cx);
                if (txtCodigo.Text == "")
                {
                    bll.Inserir(modelo);
                    Mensagem("FORNECEDOR INSERIDO CÓDIGO: " + modelo.for_cod, Color.Blue);
                }
                else
                {
                    modelo.for_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    Mensagem("FORNECEDOR ALTERADO", Color.Blue);
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
        private void PreencheCampos(ModeloFornecedor modelo)
        {
            txtCodigo.Text = modelo.for_cod.ToString();
            txtNome.Text = modelo.for_nome;
            txtRazaoSocial.Text = modelo.for_rsocial;
            mktCnpj.Text = modelo.for_cnpj;
            mktIe.Text = modelo.for_ie;
            mktCep.Text = modelo.for_cep;
            cbxSgl.Text = modelo.for_sgl;
            cbxEstado.Text = modelo.for_estado;
            cbxCidade.Text = modelo.for_cidade;
            cbxBairro.Text = modelo.for_bairro;
            cbxLogradouro.Text = modelo.for_logradouro;
            txtComplemento.Text = modelo.for_complemento;
            txtNumero.Text = modelo.for_numero;
            txtEmail.Text = modelo.for_email;
            mktTelefone.Text = modelo.for_telefone;
            mktCelular.Text = modelo.for_celular;
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
                    Mensagem("DIGITE O NOME DO FORNECEDOR ", Color.Red);
                    break;
                case "rsocial":
                    txtRazaoSocial.Focus();
                    Mensagem("DIGITE A RAZÃO SOCIAL DO FORNECEDOR ", Color.Red);
                    break;
                case "cnpj":
                    mktCnpj.Focus();
                    Mensagem("CNPJ INVÁLIDO ", Color.Red);
                    break;
                case "ie":
                    mktIe.Focus();
                    Mensagem("DIGITE A INSCRIÇÃO ESTADUAL DO FORNECEDOR ", Color.Red);
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
                    Mensagem("DIGITE O TELEFONE DO FORNECEDOR ", Color.Red);
                    break;
                case "celular":
                    mktCelular.Focus();
                    Mensagem("DIGITE O CELULAR DO FORNECEDOR ", Color.Red);
                    break;
                default:
                    Mensagem(erro, Color.Red);
                    break;
            }
        }
        public void LocalizarFornecedor()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLFornecedor bll = new BLLFornecedor(cx);
            ModeloFornecedor modelo = bll.CarregaModeloFornecedor(codigo);
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
        #endregion

        #region "Otimização"
        private void mktCnpj_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktCnpj.Text.Trim().Length == 18)
            {
                mktIe.Focus();
            }
        }
        private void mktIe_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktIe.Text.Trim().Length == 15)
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
        private void mktTelefone_KeyUp(object sender, KeyEventArgs e)
        {
            if (mktTelefone.Text.Length == 13)
            {
                mktCelular.Focus();
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
