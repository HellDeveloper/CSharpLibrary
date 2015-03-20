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
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetFieldName<T>(T param) where T : IDataParameter
        {
            string[] array = param.SourceColumn.Split(Assist.WHITE_SPACE);
            return array.Length > 0 ? array[0] : null;
        }

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
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object GetParameterValue(IDataParameter param)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return param.Value == null ? null : param.Value.ToString();
            return FormatSqlValue(param.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object BuildParameterValue(IDataParameter param)
        {
            return String.IsNullOrWhiteSpace(param.ParameterName) ? (param.Value == null ? null : param.Value.ToString()) : param.ParameterName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="func"></param>
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
        /// <param name="args"></param>
        /// <param name="table_name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string InsertSql<T>(IEnumerable<T> args, string table_name, Func<T, object> func) where T : IDataParameter
        {
            var tuple = IEnumerable.ToStringBuilder(args, Sql.GetFieldName, func, ", ");
            return String.Format("INSERT INTO {0} ({1}) VALUES ({2})", table_name, tuple.Item1, tuple.Item2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="table_name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string DeleteSql<T>(this IEnumerable<T> args, string table_name, Func<IEnumerable<T>, string> func) where T : IDataParameter
        {
            string where = func(args);
            if (String.IsNullOrWhiteSpace(where))
                return "DELETE FROM " + table_name;
            return String.Format("DELETE FROM {0} WHERE {1}", table_name, where);
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
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public static string GetInsertSql<T>(this IEnumerable<T> args, string table_name) where T : IDataParameter
        {
            return Sql.InsertSql(args as IEnumerable<IDataParameter>, table_name, Sql.GetParameterValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public static string GetDeleteSql<T>(this IEnumerable<T> args, string table_name) where T : IDataParameter
        {
            return Sql.DeleteSql(args, table_name, Sql.GetConditionSql);
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public static string BuildInsertSql<T>(this IEnumerable<T> args, string table_name) where T : IDataParameter
        {
            return Sql.InsertSql(args as IEnumerable<IDataParameter>, table_name, Sql.BuildParameterValue);
        }

        public static string BuilDeleteSql<T>(this IEnumerable<T> args, string table_name) where T : IDataParameter
        {
            return Sql.DeleteSql(args, table_name, Sql.BuildConditionSql);
        }
    }

}
