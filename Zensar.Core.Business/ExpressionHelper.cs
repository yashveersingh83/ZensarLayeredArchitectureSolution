using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Zensar.Core.DBEntities.Filters;

namespace Zensar.Core.Business
{
    public class ExpressionHelper<T> where T:class 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GenerateFilterExpression(List<FilterCriteria> filters)
        {
            Expression<Func<T, bool>> mainExpression = null;

            BinaryExpression binaryExpression = null;

            var entityType = typeof(T);

            var parameter = Expression.Parameter(entityType);

            if (filters != null)
            {
                if (filters.Any())
                {
                    foreach (var filterToItem in filters)
                    {
                        var propertyName = filterToItem.Name;

                        var propertyValue = filterToItem.Value;

                        if (binaryExpression == null)
                        {
                            binaryExpression = Expression.MakeBinary(ExpressionType.Equal, Expression.Constant(1), Expression.Constant(1));
                        }


                        switch (filterToItem.Operation)
                        {
                            case BitWiseOperation.Default:

                                switch (filterToItem.Operator)
                                {
                                    case Operator.EqualTo:

                                        binaryExpression = Expression.And(
                                                           binaryExpression,
                                                           Expression.Lambda(Expression.Equal(Expression.Property(parameter, propertyName), Expression.Constant(propertyValue)), parameter).Body
                                                           );

                                        break;

                                    case Operator.NotEqualTo:

                                        binaryExpression = Expression.And(
                                                           binaryExpression,
                                                           Expression.Lambda(Expression.NotEqual(Expression.Property(parameter, propertyName), Expression.Constant(propertyValue)), parameter).Body
                                                           );

                                        break;

                                    case Operator.Contains:

                                        binaryExpression = Expression.And(
                                                           binaryExpression,
                                                           GenerateInExpression(propertyName, propertyValue, parameter).Body
                                                           );

                                        break;

                                    case Operator.NotContains:

                                        binaryExpression = Expression.And(
                                                           binaryExpression,
                                                           GenerateNotInExpression(propertyName, propertyValue, parameter).Body
                                                           );

                                        break;
                                }

                                break;

                            case BitWiseOperation.Or:

                                switch (filterToItem.Operator)
                                {
                                    case Operator.EqualTo:

                                        binaryExpression = Expression.Or(
                                                           binaryExpression,
                                                           Expression.Lambda(Expression.Equal(Expression.Property(parameter, propertyName), Expression.Constant(propertyValue)), parameter).Body
                                                           );

                                        break;

                                    case Operator.NotEqualTo:

                                        binaryExpression = Expression.Or(
                                                           binaryExpression,
                                                           Expression.Lambda(Expression.NotEqual(Expression.Property(parameter, propertyName), Expression.Constant(propertyValue)), parameter).Body
                                                           );

                                        break;

                                    case Operator.Contains:

                                        binaryExpression = Expression.Or(
                                                           binaryExpression,
                                                           GenerateInExpression(propertyName, propertyValue, parameter).Body
                                                           );

                                        break;

                                    case Operator.NotContains:

                                        binaryExpression = Expression.And(
                                                           binaryExpression,
                                                           GenerateNotInExpression(propertyName, propertyValue, parameter).Body
                                                           );

                                        break;
                                }

                                break;
                        }

                    }

                }
            }

            if (binaryExpression != null)
            {
                mainExpression = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);
            }

            return mainExpression;
        }



        /// <summary>
        /// Creates an In expression for the specified property and property values
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GenerateInExpression(string propertyName, object propertyValue, ParameterExpression p)
        {
            Expression<Func<T, bool>> inClauseExpression = null;

            BinaryExpression orBinaryExpression = null;

            var values = (object[])propertyValue;

            if (values.Any())
            {
                foreach (var value in values.ToList())
                {
                    if (orBinaryExpression == null)
                    {
                        orBinaryExpression = Expression.MakeBinary(ExpressionType.NotEqual, Expression.Constant(1), Expression.Constant(1));
                    }

                    orBinaryExpression = Expression.Or(orBinaryExpression, Expression.Lambda(Expression.Equal(Expression.Property(p, propertyName), Expression.Constant(value)), p).Body);
                }
            }

            if (orBinaryExpression != null)
            {
                inClauseExpression = Expression.Lambda<Func<T, bool>>(orBinaryExpression, p);
            }

            return inClauseExpression;
        }



        /// <summary>
        /// Creates a Not-In expression for the specified property and property values
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GenerateNotInExpression(string propertyName, object propertyValue, ParameterExpression p)
        {
            Expression<Func<T, bool>> inClauseExpression = null;

            BinaryExpression orBinaryExpression = null;

            var values = (object[])propertyValue;

            if (values.Any())
            {
                foreach (var value in values)
                {
                    if (orBinaryExpression == null)
                    {
                        orBinaryExpression = Expression.MakeBinary(ExpressionType.NotEqual, Expression.Constant(1), Expression.Constant(1));
                    }

                    orBinaryExpression = Expression.Or(orBinaryExpression, Expression.Lambda(Expression.NotEqual(Expression.Property(p, propertyName), Expression.Constant(value)), p).Body);
                }
            }

            if (orBinaryExpression != null)
            {
                inClauseExpression = Expression.Lambda<Func<T, bool>>(orBinaryExpression, p);
            }

            return inClauseExpression;
        }
    }
}
