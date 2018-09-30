using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using AB.NambuImoveis.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    //removi e coloquei IRepositoryWrite separado
    public class Repository<TEntity> : IRepositoryWrite<TEntity>, IRepository<TEntity> where TEntity : class
    {
        //protected IUnitOfWork Db;
        protected NambuImoveisContext Db;
        protected DbSet<TEntity> DbSet;     
        
        public Repository(NambuImoveisContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
            context.Database.Log = x => Debug.Write(x);

        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {            
            var result = DbSet.Find(id);
            return result;
        }
        
        public virtual IEnumerable<TEntity> ObterTodos()
        {
            
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Skip(s).Take(t).ToList();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objRet = DbSet.Add(obj);
            //SaveChanges();
            return objRet;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            //SaveChanges();
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            //var entity = new TEntity { Id = id };
            DbSet.Remove(DbSet.Find(id));
            //SaveChanges();
        }

        public virtual void Remover(TEntity obj)
        {
            //var entity = new TEntity { Id = id };
            DbSet.Attach(obj);
            DbSet.Remove(obj);
            //SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }


        //public virtual TEntity ObterPorId(Expression<Func<TEntity, bool>> predicate, string property = null)
        //{
        //    IQueryable<TEntity> query = DbSet;
        //    foreach (var propertyName in property.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(propertyName);
        //    }
        //    //var query = from pessoa in Db.Pessoas
        //    //            join pessoaFisica in Db.PessoaFisicas on pessoa.Id equals pessoaFisica.Id
        //    //            where pessoa.Id == id
        //    //            select new {TEntity = pessoa};
        //    //var result = DbSet.Find(id);
        //    if (property != null)
        //    {
        //        var result = query.Where(predicate).First();
        //        return result;
        //    }
        //    else
        //    {
        //        var result = DbSet.Where(predicate).FirstOrDefault();
        //        return result;
        //    }

        //}
    }
}
