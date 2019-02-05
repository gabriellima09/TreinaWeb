using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ProdutosMarcas.Apresentacao.ViewModels
{
    class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }
    }
}
