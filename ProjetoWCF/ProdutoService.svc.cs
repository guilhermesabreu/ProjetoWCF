
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProdutoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProdutoService.svc or ProdutoService.svc.cs at the Solution Explorer and start debugging.
    public class ProdutoService : IProdutoService
    {

        private ProjetoModeloDBEntities _db;

        public List<Produto> FindAll()
        {
            using (_db = new ProjetoModeloDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                List<Produto> produtos = _db.Produto.Include("Cliente").ToList();
                return produtos;
            }
        }

        public Produto Find(int id)
        {
            using (_db = new ProjetoModeloDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Produto produto = _db.Produto.Single(x => x.ProdutoId.Equals(id));
                return produto;
            }
        }

        public Produto New(Produto produto)
        {
            using (_db = new ProjetoModeloDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Produto.Add(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto Update(Produto produto)
        {
            using (_db = new ProjetoModeloDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Entry(produto).State = EntityState.Modified;
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto DeleteId(int id)
        {
            using (_db = new ProjetoModeloDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Produto produto = _db.Set<Produto>().Find(id);
                _db.Set<Produto>().Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto Delete(Produto produto)
        {
            using (_db = new ProjetoModeloDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Set<Produto>().Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }
    }
}