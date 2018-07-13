using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu olarak tek kaydı döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static TEntity GetSingle<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> filter)
             where TEntity : class
        { 
            return dbSet.Where(filter).SingleOrDefault();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu olarak ilk kaydı döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static TEntity GetFirst<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).FirstOrDefault() : dbSet.FirstOrDefault();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu olarak son kaydı döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static TEntity GetLast<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).LastOrDefault() : dbSet.LastOrDefault();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu dizi olarak döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static TEntity[] GetArray<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).ToArray() : dbSet.ToArray();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu liste olarak döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<TEntity> GetList<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).ToList() : dbSet.ToList();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu sayfalama ile dizi olarak döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static TEntity[] GetArrayWithPaging<TEntity>(this DbSet<TEntity> dbSet, int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).Skip(pageNumber).Take(pageSize).ToArray() : dbSet.Skip(pageNumber).Take(pageSize).ToArray();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu sayfalama ile liste olarak döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<TEntity> GetListWithPaging<TEntity>(this DbSet<TEntity> dbSet, int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).Skip(pageNumber).Take(pageSize).ToList() : dbSet.Skip(pageNumber).Take(pageSize).ToList();
        }

        /// <summary>
        /// Filtreli/filtresiz sorgu sonucunu sayfalama ile IQueryable sınıfından liste olarak döner.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetIQueryableWithPaging<TEntity>(this DbSet<TEntity> dbSet, int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null)
             where TEntity : class
        {
            return filter != null ? dbSet.Where(filter).Skip(pageNumber).Take(pageSize) : dbSet.Skip(pageNumber).Take(pageSize);
        }

        /// <summary>
        /// Entity nesnesini SaveChanges ile kaydeder.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void InsertWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, TEntity entity)
            where TEntity : class
        {
            try
            {
                dbSet.Add(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile kaydeder.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void InsertWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, params TEntity[] entities)
            where TEntity : class
        {
            try
            {
                dbSet.AddRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile kaydeder.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void InsertWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, List<TEntity> entities)
            where TEntity : class
        {
            try
            {
                dbSet.AddRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile kaydeder.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void InsertWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            try
            {
                dbSet.AddRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnesini SaveChanges ile günceller.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void UpdateWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, TEntity entity)
            where TEntity : class
        {
            try
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile günceller.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void UpdateWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, params TEntity[] entities)
            where TEntity : class
        {
            try
            {
                foreach (var entity in entities)
                {
                    dbSet.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile günceller.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void UpdateWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, List<TEntity> entities)
            where TEntity : class
        {
            try
            {
                foreach (var entity in entities)
                {
                    dbSet.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile günceller.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void UpdateWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            try
            {
                foreach (var entity in entities)
                {
                    dbSet.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnesini SaveChanges ile siler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void DeleteWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, TEntity entity)
            where TEntity : class
        {
            try
            {
                dbSet.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile siler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void DeleteWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, params TEntity[] entities)
            where TEntity : class
        {
            try
            {
                dbSet.RemoveRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile siler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void DeleteWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, List<TEntity> entities)
            where TEntity : class
        {
            try
            {
                dbSet.RemoveRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile siler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void DeleteWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            try
            {
                dbSet.RemoveRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Entity nesnelerini SaveChanges ile siler.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public static void DeleteWithSaveChanges<TEntity>(this DbSet<TEntity> dbSet, DbContext context, Expression<Func<TEntity, bool>> filter)
            where TEntity : class
        {
            try
            {
                var entities = dbSet.Where(filter);
                dbSet.RemoveRange(entities);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
