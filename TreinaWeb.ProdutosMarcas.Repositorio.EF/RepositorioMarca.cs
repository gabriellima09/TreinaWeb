using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.ProdutosMarcas.Dominio;
using TreinaWeb.ProdutosMarcas.Persistencia.EF.Context;
using TreinaWeb.Repositorio.Comum;

namespace TreinaWeb.ProdutosMarcas.Repositorio.EF
{
    public class RepositorioMarca : IRepositorioGenerico<Marca>
    {
        public void Atualizar(Marca entidade)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                context.Marcas.Attach(entidade);
                context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(Marca entidade)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                context.Marcas.Attach(entidade);
                context.Entry(entidade).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Inserir(Marca entidade)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                context.Marcas.Add(entidade);
                context.SaveChanges();
            }
        }

        public Marca SelecionarPorId(int id)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                return context.Marcas.Find(id);
            }
        }

        public Task<List<Marca>> SelecionarTodos()
        {
            return Task.Run(() =>
            {
                using (var context = new ProdutosMarcasDbContext())
                {
                    return context.Marcas.ToList();
                }
            });
        }
    }
}
