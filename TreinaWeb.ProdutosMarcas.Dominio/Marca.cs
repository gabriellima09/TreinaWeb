using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ProdutosMarcas.Dominio
{
    public class Marca : EntidadeDominio
    {
        public IList<Produto> Produtos { get; set; }
    }
}
