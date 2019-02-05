using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.ProdutosMarcas.Dominio
{
    public abstract class EntidadeDominio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
