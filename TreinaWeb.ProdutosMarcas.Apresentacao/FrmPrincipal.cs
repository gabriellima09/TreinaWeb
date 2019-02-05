using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreinaWeb.ProdutosMarcas.Apresentacao.ViewModels;
using TreinaWeb.ProdutosMarcas.Dominio;
using TreinaWeb.ProdutosMarcas.Repositorio.EF;
using TreinaWeb.Repositorio.Comum;

namespace TreinaWeb.ProdutosMarcas.Apresentacao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            PreencherDataGridViewMarcasAsync();
            PreencherDataGridViewProdutosAsync();
        }

        private async void PreencherDataGridViewMarcasAsync()
        {
            IRepositorioGenerico<Marca> repMarca = new RepositorioMarca();
            List<Marca> marcas = await repMarca.SelecionarTodos();
            List<MarcaViewModel> marcaViewModels = new List<MarcaViewModel>();

            marcas.ForEach(x => marcaViewModels.Add(new MarcaViewModel()
            {
                Id = x.Id,
                Descricao = x.Descricao
            }));

            dgvMarcas.Invoke((MethodInvoker)delegate 
            {
                dgvMarcas.DataSource = marcaViewModels;
                dgvMarcas.Refresh();
            });
        }

        private async void PreencherDataGridViewProdutosAsync()
        {
            IRepositorioGenerico<Produto> repProduto = new RepositorioProduto();
            List<Produto> produtos = await repProduto.SelecionarTodos();
            List<ProdutoViewModel> produtoViewModels = new List<ProdutoViewModel>();

            produtos.ForEach(x => produtoViewModels.Add(new ProdutoViewModel()
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Marca = x.Marca.Descricao,
                MarcaId = x.MarcaId
            }));

            dgvProdutos.Invoke((MethodInvoker)delegate
            {
                dgvProdutos.DataSource = produtoViewModels;
                dgvProdutos.Refresh();
            });
        }
    }
}
