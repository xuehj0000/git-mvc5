using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Auth.Common;

namespace Auth.Interface
{
    public interface IBaseService:IDisposable
    {
        T Find<T>(int id) where T : class;

        /// <summary>
        /// 提供对表单的查询
        /// </summary>
        [Obsolete("尽量避免使用，using 带表达式目录的 代替")]
        IQueryable<T> Set<T>() where T : class;

        IQueryable<T> Query<T>(Expression<Func<T, bool>> exps) where T : class;

        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> exps, int pageSize, int pageIndex, Expression<Func<T, S>> orderBy, bool isAsc = true) where T : class;
   
    
        T Insert<T>(T t) where T:class;

        void Update<T>(T t) where T : class;

        void Update<T>(IEnumerable<T> list) where T : class;

        void Delete<T>(int id) where T : class;

        void Delete<T>(T t) where T : class;

        void Delete<T>(IEnumerable<T> list) where T : class;

        void Commit();

        bool Exist<T>(Expression<Func<T, bool>> exps) where T:class;

        IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class;

        void Excute<T>(string sql, SqlParameter[] parameters) where T : class;
    }
}
