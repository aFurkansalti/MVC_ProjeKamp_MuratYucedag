using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class  // T değeri bir class olmalı demiş olduk
    {
        Context context = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            this._object = this.context.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = context.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //this._object.Remove(p);
            this.context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return this._object.SingleOrDefault(filter); 
        }

        public void Insert(T p)
        {
            var addedEntity = context.Entry(p);
            addedEntity.State = EntityState.Added;
            //this._object.Add(p);
            this.context.SaveChanges();  
        }

        public List<T> List()
        {
            return this._object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return this._object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = context.Entry(p);
            updatedEntity.State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
