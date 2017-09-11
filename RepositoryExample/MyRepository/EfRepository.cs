using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RepositoryExample.Models;

namespace RepositoryExample.MyRepository
{
    public class EfRepository<T>:IRepository<T> where T:class
    {
        private readonly UsersContext _context;

        public EfRepository(UsersContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 返回一个实体集合
        /// </summary>
        private DbSet<T> Entity
        {
            get { return _context.Set<T>(); }
        }

        public T GetById(object id)
        {
            return this.Entity.Find(id);
        }

        public void Insert(T entity)
        {
            this.Entity.Add(entity);
            this._context.SaveChanges();
        }

        public void Update(T entity)
        {
            this._context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.Entity.Remove(entity);
            this._context.SaveChanges();
        }

        public virtual IQueryable<T> Table
        {
            get { return this.Entity; }

        }
    }
}