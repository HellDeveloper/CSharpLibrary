using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Collections;
using Utility.Core;
using Utility.Data;

namespace Utility.Sql
{
    /// <summary>
    /// 共用部分
    /// </summary>
    public abstract class Share
    {

        /// <summary>
        /// 0:table_name, 1:field_names, 2:values
        /// </summary>
        public static string InsertSqlFormat
        {
            get { return "INSERT INTO {0}({1}) VALUES({2})"; }
        }

        /// <summary>
        /// 0:table_name, 1:sets, 2:where
        /// </summary>
        public static string UpdateSqlFormat
        {
            get { return "UPDATE {0} SET {1} WHERE 1=1 AND {2}"; }
        }

        /// <summary>
        /// 0:table_name, 1:where
        /// </summary>
        public static string DeleteSqlFormat
        {
            get { return "DELETE FROM {0} WHERE 1=1 AND {1}"; }
        }

        #region Lambda
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected virtual object ReturnParameterName(IDataParameter param)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return null;
            return param.ParameterName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected virtual object ReturnFormatSqlValue(IDataParameter param)
        {
            return this.GetFormatSqlValue(param.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        protected virtual string ReturnUpdateSet<T>(IDataParameter param, Func<IDataParameter, T> func)
        {
            string fieldname = DbParameter.GetFieldName(param);
            if (String.IsNullOrWhiteSpace(fieldname))
                return null;
            return String.Format("{0} = {1}", fieldname, func(param));
        }

        /// <summary>
        /// fieldName = value
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected virtual string ReturnUpdateSetValue(IDataParameter param)
        {
            return this.ReturnUpdateSet(param, this.ReturnFormatSqlValue);
        }

        /// <summary>
        /// fieldName = parameterName
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected virtual string ReturnUpdateSetParameterName(IDataParameter param)
        {
            return this.ReturnUpdateSet(param, this.ReturnParameterName);
        }
        #endregion

        /// <summary>
        /// /
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        protected virtual A ReturnItem1<A, B>(Tuple<A, B> tuple)
        {
            return tuple.Item1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        protected virtual B ReturnItem2<A, B>(Tuple<A, B> tuple)
        {
            return tuple.Item2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual object GetFormatSqlValue(object value)
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

        #region Get Sql
        /// <summary>
        /// 获取条件Sql
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual string GetConditionSql(IDataParameter param)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return param.SourceColumn;
            return String.Format("{0}{1}{2}", param.SourceColumn, Assist.WHITE_SPACE, this.GetFormatSqlValue(param.Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual string GetConditionSql(IEnumerable<IDataParameter> args)
        {
            return IEnumerable.ToStringBuilder(args, this.GetConditionSql, " AND ").ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual string GetInsertSql(string tableName, IEnumerable<IDataParameter> args)
        {
            var tuple = IEnumerable.ToStringBuilder(args, DbParameter.GetFieldName, this.ReturnFormatSqlValue);
            return String.Format(Share.InsertSqlFormat, tableName, tuple.Item1, tuple.Item2);
        }

        /// <summary>
        /// 获取更新sql
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="sets"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual string GetUpdateSql(string tableName, IEnumerable<IDataParameter> sets, IEnumerable<IDataParameter> where)
        {
            return String.Format(UpdateSqlFormat, tableName, IEnumerable.ToStringBuilder(sets, this.ReturnUpdateSetValue), this.GetConditionSql(where));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual string GetDeleteSql(string tableName, IEnumerable<IDataParameter> where)
        {
            return String.Format(DeleteSqlFormat, tableName, this.GetConditionSql(where));
        }
        #endregion

        #region Build Sql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual string BuildConditionSql(IDataParameter param)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return param.SourceColumn;
            return String.Format("{0}{1}{2}", param.SourceColumn, Assist.WHITE_SPACE, param.ParameterName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual string BuildConditionSql(IEnumerable<IDataParameter> args)
        {
            return IEnumerable.ToStringBuilder(args, this.BuildConditionSql, " AND ").ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual string BuildInsertSql(string tableName, IEnumerable<IDataParameter> args)
        {
            var tuple = IEnumerable.ToStringBuilder(args, DbParameter.GetFieldName, this.ReturnParameterName);
            return String.Format(Share.InsertSqlFormat, tableName, tuple.Item1, tuple.Item2);
        }

        /// <summary>
        /// 构建更新sql语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="sets"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual string BuildUpdateSql(string tableName, IEnumerable<IDataParameter> sets, IEnumerable<IDataParameter> where)
        {
            return String.Format(UpdateSqlFormat, tableName, IEnumerable.ToStringBuilder(sets, this.ReturnUpdateSetParameterName), this.BuildConditionSql(where)); 
        }

        /// <summary>
        /// 构建删除的sql语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual string BuildDeleteSql(string tableName, IEnumerable<IDataParameter> where)
        {
            return String.Format(DeleteSqlFormat, tableName, this.BuildConditionSql(where));
        }
        #endregion

        /// <summary>
        /// 分页 Sql
        /// </summary>
        /// <param name="index">第几页（从0开始）</param>
        /// <param name="pageSize">每一页的大小</param>
        /// <param name="selectSql">查询的SQL语句</param>
        /// <param name="orderBy"></param>
        /// <returns>返回新的SQL语句</returns>
        public abstract string AppendPageSql(string selectSql, int index, int pageSize, string orderBy = "ID ASC");

    }
}
