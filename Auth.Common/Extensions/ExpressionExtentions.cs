using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Common.Extensions
{
    public static class ExpressionExtentions
    {
        public static Expression<Func<T,bool>> And<T>(this Expression<Func<T,bool>> exps1, Expression<Func<T,bool>> exps2)
        {
            if(exps1 == null)
            {
                return exps2;
            }
            ParameterExpression newParameter = Expression.Parameter(typeof(T), "c");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);
            var left = visitor.Replace(exps1.Body);
            var right = visitor.Replace(exps2.Body);
            var body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        /// <summary>
        /// 合并表达式or
        /// </summary>
        public static Expression<Func<T,bool>> Or<T>(this Expression<Func<T,bool>> exps, Expression<Func<T, bool>> exps2)
        {
            ParameterExpression newParameter = Expression.Parameter(typeof(T), "c");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);
            var left = visitor.Replace(exps.Body);
            var right = visitor.Replace(exps2.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        public static Expression<Func<T,bool>> Not<T>(this Expression<Func<T,bool>> exps)
        {
            var candidateExpr = exps.Parameters[0];
            var body = Expression.Not(exps.Body);
            return Expression.Lambda<Func<T, bool>>(body, candidateExpr); 
        }
    }


    public class NewExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression _newParameter { get; private set; }
        public NewExpressionVisitor(ParameterExpression param)
        {
            this._newParameter = param;
        }
        public Expression Replace(Expression exp)
        {
            return this.Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this._newParameter;
        }

    }

}
