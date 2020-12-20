using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace LibraryProject.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "LibraryDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection db = new SqlConnection(GetConnectionString()))
            {
                return db.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection db = new SqlConnection(GetConnectionString()))
            {
                return db.Execute(sql, data);
            }
        }

        public static void Execute(string sql)
        {
            using (IDbConnection db = new SqlConnection(GetConnectionString()))
            {
                db.Execute(sql);
            }
        }
    }
}