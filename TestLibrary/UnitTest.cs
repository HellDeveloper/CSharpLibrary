using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.Sql;
using Utility.Data;

namespace TestLibrary
{
    [TestClass]
    public class UnitTest
    {
        const string ConnStr = "Server=.; Database=Test; User ID=sa; Password=123;";

        const string TableName = "Profile";

        SqlConnection conn = new SqlConnection(ConnStr);

        MsSql mssql = new MsSql();

        [TestMethod]
        public List<SqlParameter> CreateParameter(string name, string sex, string bornDate, string IDCardNumber, string address)
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@Name", name) { SourceColumn = "Name LIKE" } ,
                new SqlParameter("@Sex", sex) { SourceColumn = "Sex LIKE" },
                new SqlParameter("@BornDate", bornDate) { SourceColumn = "BornDate >=" },
                new SqlParameter("@IDCardNumber", IDCardNumber),
                new SqlParameter("@Address", address)
            };
        }

        [TestMethod]
        public void NonQuery()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            var args = this.CreateParameter("Jack", "男", "1989-10-10", "123456789987654321", "东莞市");
            string insert_sql = mssql.BuildInsertSql(TableName, args);
            conn.ExecuteNonQuery(insert_sql, args);
            string delete_sql = mssql.BuildDeleteSql(TableName, args);
            conn.ExecuteNonQuery(delete_sql, args);
        }

    }
}
