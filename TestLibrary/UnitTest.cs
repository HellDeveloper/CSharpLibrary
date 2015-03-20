using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.Data;

namespace TestLibrary
{
    [TestClass]
    public class UnitTest
    {
        const string ConnStr = "Server=.; Database=Test; User ID=sa; Password=123;";

        const string TableName = "Profile";

        SqlConnection conn = new SqlConnection(ConnStr);

        [TestMethod]
        public List<SqlParameter> CreateParameter(string name, string sex, string bornDate)
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@Name", name) { SourceColumn = "Name LIKE" } ,
                new SqlParameter("@Sex", sex) { SourceColumn = "Sex LIKE" },
                new SqlParameter("@BornDate", bornDate) { SourceColumn = "BornDate >=" }
            };
        }

        [TestMethod]
        public void NonQuery()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            var args = this.CreateParameter("Jack", "男", "1989-10-10");
            args.Add("@IDcardNumber", "123456789", "IDCardNumber");
            args.Add("@Address", "东莞市", "Address");
            string insert_sql = args.BuildInsertSql(TableName);
            conn.ExecuteNonQuery(insert_sql, args);
            //string delete_sql = args.BuildDeleteSql(TableName);
            //conn.ExecuteNonQuery(delete_sql, args);
        }

    }
}
