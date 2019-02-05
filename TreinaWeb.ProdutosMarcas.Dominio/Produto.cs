using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ProdutosMarcas.Dominio
{
    public class Produto : EntidadeDominio
    {
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }
    }
}
