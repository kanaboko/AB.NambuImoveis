using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class RepositoryWrite<TEntity> : IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected NambuImoveisContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryWrite()
        {
            Db = new NambuImoveisContext();
            DbSet = Db.Set<TEntity>();
        
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objRet = DbSet.Add(obj);
            SaveChanges();
            return objRet;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            //var entity = new TEntity { Id = id };
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Remover(TEntity obj)
        {
            //var entity = new TEntity { Id = id };
            DbSet.Attach(obj);
            DbSet.Remove(obj);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
