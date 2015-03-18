using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Data
{
    /// <summary>
    /// 数据库
    /// </summary>
    public static class DbTool
    { 
        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static bool OpenConnection(this IDbConnection conn)
        {
            if (conn.State == ConnectionState.Broken)
                conn.Close();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn.State == ConnectionState.Open;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static bool CloseConnection(this IDbConnection conn)
        {
            if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Open)
                conn.Close();
            return conn.State == ConnectionState.Closed;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IDbCommand CreateCommand(this IDbConnection conn, string sql, IEnumerable<IDataParameter> args)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            foreach (var item in args)
            {
                if (item == null || String.IsNullOrWhiteSpace(item.ParameterName))
                    continue;
                if (item.Value == null)
                    item.Value = DBNull.Value;
                if (cmd.CommandType != CommandType.StoredProcedure && item.Direction != ParameterDirection.Input)
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(item);
            }
            
            if (cmd.CommandType != CommandType.StoredProcedure && sql.IndexOf(Utility.Core.Assist.WHITE_SPACE, 0) == -1)
                cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        internal static T Execute<T>(IDbConnection conn, string sql, IEnumerable<IDataParameter> args, Func<IDbCommand, T> func)
        {
            bool need_close = conn.State == ConnectionState.Closed;
            IDbCommand cmd = DbTool.CreateCommand(conn, sql, args);
            DbTool.OpenConnection(conn);
            T temp = func.Invoke(cmd);
            if (need_close)
                DbTool.CloseConnection(conn);
            cmd.Parameters.Clear();
            return temp;
        }

        /// <summary>
        /// IDbCommand执行ExecuteNonQuery
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        internal static int ExecuteNonQuery(IDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// IDbCommand执行ExecuteScalar
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        internal static object ExecuteScalar(IDbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static bool TryAddColumn(DataTable table, string name)
        {
            try
            {
                table.Columns.Add(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this IDbConnection conn, string sql, IEnumerable<IDataParameter> args)
        {
            return DbTool.Execute(conn, sql, args, DbTool.ExecuteNonQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object ExecuteScalar(this IDbConnection conn, string sql, IEnumerable<IDataParameter> args)
        {
            return DbTool.Execute(conn, sql, args, DbTool.ExecuteScalar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T ExecuteReader<T>(this IDbConnection conn, string sql, IEnumerable<IDataParameter> args, Func<IDataReader, T> func)
        {
            CommandBehavior behavior = conn.State == ConnectionState.Closed ? CommandBehavior.CloseConnection : CommandBehavior.Default;
            IDataReader reader = DbTool.GetDataReader(conn, sql, args, behavior);
            T temp = func(reader);
            if (!reader.IsClosed)
                reader.Close();
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public static IDataReader GetDataReader(this IDbConnection conn, string sql, IEnumerable<IDataParameter> args, CommandBehavior behavior = CommandBehavior.CloseConnection)
        {
            IDbCommand cmd = DbTool.CreateCommand(conn, sql.Trim(), args);
            DbTool.OpenConnection(conn);
            var temp = cmd.ExecuteReader(behavior);
            cmd.Parameters.Clear();
            return temp;
        }

        /// <summary>
        /// IDataReader 转 DataTable
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DataTable IDataReaderToDataTable(IDataReader reader)
        {
            DataTable table = new DataTable();
            List<int> list = new List<int>();
            for (int i = 0; i < reader.FieldCount; i++)
                if (DbTool.TryAddColumn(table, reader.GetName(i)))
                    list.Add(i);
            while (reader.Read())
            {
                object[] array = new object[list.Count];
                int index = 0;
                foreach (var item in list)
                    array[index++] = reader.GetValue(item);
                table.Rows.Add(array);
            }
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(this IDbConnection conn, string sql, IEnumerable<IDataParameter> args)
        {
            return DbTool.ExecuteReader(conn, sql, args, DbTool.IDataReaderToDataTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destine">指定</param>
        public static void CopyParameter(IDataParameter source, IDataParameter destine)
        {
            destine.DbType = source.DbType;
            destine.Direction = source.Direction;
            destine.ParameterName = source.ParameterName;
            destine.SourceColumn = source.SourceColumn;
            destine.Value = source.Value;
        }

    }
}
