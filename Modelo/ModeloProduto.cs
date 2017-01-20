using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloProduto
    {
        #region "Propriedades"
        public int ProCod { get; set; }
        public string ProNome { get; set; }
        public string ProDescricao { get; set; }
        public byte[] ProFoto { get; set; }
        public double ProValorPago { get; set; }
        public double ProValorVenda { get; set; }
        public double ProQtde { get; set; }
        public int UmedCod { get; set; }
        public int CatCod { get; set; }
        public int ScatCod { get; set; }
        #endregion

        #region "Eventos"
        public ModeloProduto()
        {
            ProCod = 0;
            ProNome = "";
            ProDescricao = "";
            //Null
            ProValorPago = 0;
            ProValorVenda = 0;
            ProQtde = 0;
            UmedCod = 0;
            CatCod = 0;
            ScatCod = 0;
        }
        public ModeloProduto(int proCod, string proNome, string proDescricao, string proFoto, double proValorPago, double proValorVenda, double proQtde, int umedCod, int catCod, int sCatCod)
        {
            this.ProCod = proCod;
            this.ProNome = proNome;
            this.ProDescricao = proDescricao;
            this.CarregaImagem(proFoto);
            this.ProValorPago = proValorPago;
            this.ProValorVenda = proValorVenda;
            this.ProQtde = proQtde;
            this.UmedCod = umedCod;
            this.CatCod = catCod;
            this.ScatCod = sCatCod;
        }
        public ModeloProduto(int proCod, string proNome, string proDescricao, byte[] proFoto, double proValorPago, double proValorVenda, double proQtde, int umedCod, int catCod, int sCatCod)
        {
            this.ProCod = proCod;
            this.ProNome = proNome;
            this.ProDescricao = proDescricao;
            this.ProFoto = proFoto;
            this.ProValorPago = proValorPago;
            this.ProValorVenda = proValorVenda;
            this.ProQtde = proQtde;
            this.UmedCod = umedCod;
            this.CatCod = catCod;
            this.ScatCod = sCatCod;
        }
        public void CarregaImagem(string imgcaminho)
        {
            try
            {
                if (string.IsNullOrEmpty(imgcaminho))
                    return;
                //Fornece propriedade método de instância para criar, copiar, excluir, mover e abrir arquivos, e ajuda na criação de objetos FileStream
                FileInfo arqImagem = new FileInfo(imgcaminho);
                //Expões um stream ao redor de um arquivo de suporte sincrono e assincrono operações de leitura e gravar
                FileStream fs = new FileStream(imgcaminho, FileMode.Open, FileAccess.Read, FileShare.Read);
                //Aloca a memória para o vetor
                this.ProFoto = new byte[Convert.ToInt32(arqImagem.Length)];
                //Lê um bloco de bytes do fluxo e grava os dadosem um buffer fornecido
                int iBytesRead = fs.Read(this.ProFoto, 0, Convert.ToInt32(arqImagem.Length));
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion
    }
}
