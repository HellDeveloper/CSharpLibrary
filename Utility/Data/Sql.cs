using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Collections;
using Utility.Core;

namespace Utility.Data
{
    /// <summary>
    /// SQL语句
    /// </summary>
    public static class Sql
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object FormatSqlValue(object value)
        {
            if (value == null || value is DBNull)
                return "NULL";
            else if (value is String)
                return String.Format("'{0}'", ((String)value).Replace("'", "''"));
            else if (value is DateTime)
                return String.Format("'{0}'", ((DateTime)value).ToString(Assist.ISO_DATETIME_FORMAT));
            else
                return value.ToString();
        }

        /// <summary>
        /// 返回ParameterName
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object GetParameterName(IDataParameter param)
        {
            return param.ParameterName;
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string ConditionSql(IDataParameter param, Func<IDataParameter, object> func)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return param.Value == null ? null : param.Value.ToString();
            return String.Format("{0}{1}{2}", param.SourceColumn, Assist.WHITE_SPACE, func(param));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetConditionSql<T>(this T param) where T : IDataParameter
        {
            return ConditionSql(param, Sql.FormatSqlValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetConditionSql<T>(this IEnumerable<T> args) where T : IDataParameter
        {
            return IEnumerable.ToStringBuilder(args, Sql.GetConditionSql, " AND ").ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string BuildConditionSql<T>(this T param) where T : IDataParameter
        {
            return ConditionSql(param, Sql.GetParameterName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string BuildConditionSql<T>(this IEnumerable<T> args) where T : IDataParameter
        {
            return IEnumerable.ToStringBuilder(args, Sql.BuildConditionSql, " AND ").ToString();
        }

    }

}
