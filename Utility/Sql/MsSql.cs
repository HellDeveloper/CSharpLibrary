using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Core;

namespace Utility.Sql
{
    /// <summary>
    /// sql server
    /// </summary>
    public class MsSql : Share
    {
        /// <summary>
        /// 分页 Sql
        /// </summary>
        /// <param name="index">第几页（从0开始）</param>
        /// <param name="pageSize">每一页的大小</param>
        /// <param name="selectSql">查询的SQL语句(不允许带ORDER BY)</param>
        /// <param name="orderBy"></param>
        /// <returns>返回新的SQL语句</returns>
        public override string AppendPageSql(string selectSql, int index, int pageSize, string orderBy = "ID ASC")
        {
            return PageSqlIn2005(selectSql, index, pageSize, orderBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private static string PageSqlIn2005(string selectSql, int index, int pageSize, string orderBy)
        {
            int i = selectSql.IndexOf(Assist.WHITE_SPACE);
            selectSql = selectSql.Insert(i, String.Format(" ROW_NUMBER() OVER (ORDER BY {0}) AS __RowID,", orderBy));
            return String.Format("SELECT * FROM ({0}) AS __Temp__Table WHERE __RowID BETWEEN {1} AND {2}", selectSql, (index * pageSize) + 1, ((index + 1) * pageSize));
        }
    } 
}
