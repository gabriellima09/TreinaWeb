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
    public class RepositorioProduto : IRepositorioGenerico<Produto>
    {
        public void Atualizar(Produto entidade)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                Marca marca = context.Marcas.Find(entidade.MarcaId);
                entidade.Marca = marca;
                context.Produtos.Attach(entidade);
                context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(Produto entidade)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                context.Produtos.Attach(entidade);
                context.Entry(entidade).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Inserir(Produto entidade)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                Marca marca = context.Marcas.Find(entidade.MarcaId);
                entidade.Marca = marca;
                context.Produtos.Add(entidade);
                context.SaveChanges();
            }
        }

        public Produto SelecionarPorId(int id)
        {
            using (var context = new ProdutosMarcasDbContext())
            {
                return context.Produtos.Include("Marca").Single(s => s.Id == id);
            }
        }

        public Task<List<Produto>> SelecionarTodos()
        {
            return Task.Run(() =>
            {
                using (var context = new ProdutosMarcasDbContext())
                {
                    return context.Produtos.Include("Marca").ToList();
                }
            });
        }
    }
}
