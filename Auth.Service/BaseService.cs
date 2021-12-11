using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Auth.Common;
using Auth.DAL;
using Auth.Interface;

namespace Auth.Service
{
    public class BaseService:IBaseService
    {
        protected MyDbContext myContext { get; set; }
        
        public BaseService(MyDbContext context)
        {
            myContext = context;
        }
        public void Commit()
        {
            this.myContext.SaveChanges();
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return this.myContext.Set<T>();
        }

        public T Insert<T>(T t) where T : class
        {
            myContext.Set<T>().Add(t);
            Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> list) where T : class
        {
            myContext.Set<T>().AddRange(list);
            this.Commit();
            return list;
        }

        /// <summary>
        /// 是没有实现查询，直接更新的，需要Attach和State.如果已经context,只能再封装一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            myContext.Set<T>().Attach(t);                          // 将数据附加到上下文，支持实体修改和新实例，重置为UnChanged
            myContext.Entry<T>(t).State = EntityState.Modified;
            Commit();          // 保存，然后重置为UnChanged
        }

        public void Update<T>(IEnumerable<T> list) where T : class
        {
            foreach(var t in list)
            {
                myContext.Set<T>().Attach(t);
                myContext.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        public void Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);
            if (t == null) throw new Exception("t is null");
            this.myContext.Set<T>().Remove(t);
            this.Commit();
        }

        /// <summary>
        /// 先附加，再删除
        /// </summary>
        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.myContext.Set<T>().Attach(t);
            this.myContext.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> list) where T : class
        {
            foreach(var t in list)
            {
                this.myContext.Set<T>().Attach(t);
            }
            this.myContext.Set<T>().RemoveRange(list);
            this.Commit();
        }

        public T Find<T>(int id) where T : class
        {
            return this.myContext.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> exps=null) where T : class
        {
            if (exps == null)
                return this.myContext.Set<T>();
            else
                return this.myContext.Set<T>().Where<T>(exps);
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> exps, int pageSize, int pageIndex, Expression<Func<T, S>> orderBy, bool isAsc = true) where T : class
        {
            var query = Set<T>();
            if (exps != null)
                query = query.Where<T>(exps);

            if (isAsc)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = new PageResult<T>();
            result.Rows = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            result.Total = query.Count();
            return result;
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            return this.myContext.Database.SqlQuery<T>(sql, parameters).AsQueryable();
        }

        public void Excute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            DbContextTransaction trans = null;
            try
            {
                trans = this.myContext.Database.BeginTransaction();
                this.myContext.Database.ExecuteSqlCommand(sql, parameters);
                trans.Commit();
            }catch(Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            
        }

        public void Dispose()
        {

        }

        public bool Exist<T>(Expression<Func<T, bool>> exps) where T : class
        {
            return myContext.Set<T>().Where<T>(exps).Count() > 0;
        }
    }
}
