using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MVCSampleGrid.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public IList<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            try
            {
                List<T> list = new List<T>();

                using (var context = new MVCSampleGridEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    foreach (Expression<Func<T, object>> property in properties)
                        dbQuery = dbQuery.Include<T, object>(property);

                    list = dbQuery.AsNoTracking()
                                    .ToList<T>();

                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] properties)
        {
            try
            {
                List<T> list = new List<T>();

                using (var context = new MVCSampleGridEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    foreach (Expression<Func<T, object>> property in properties)
                        dbQuery = dbQuery.Include<T, object>(property);

                    list = dbQuery.AsNoTracking()
                                    .Where(where)
                                    .ToList<T>();

                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] properties)
        {
            try
            {
                T item=null;

                using (var context = new MVCSampleGridEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    foreach (Expression<Func<T, object>> property in properties)
                        dbQuery = dbQuery.Include<T, object>(property);

                    item = dbQuery.AsNoTracking()
                                    .FirstOrDefault(where);

                }

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(params T[] items)
        {
            try
            {
                using (var context = new MVCSampleGridEntities())
                {
                    foreach (var item in items)
                    {
                        context.Entry(item).State = EntityState.Added;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(params T[] items)
        {
            try
            {
                using (var context = new MVCSampleGridEntities())
                {
                    foreach (var item in items)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(params T[] items)
        {
            try
            {
                using (var context = new MVCSampleGridEntities())
                {
                    foreach (var item in items)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
