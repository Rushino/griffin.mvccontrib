using System;
using System.Data;
using System.Data.SqlClient;
using Griffin.MvcContrib.SqlServer.Localization;

namespace Griffin.MvcContrib.SqlServer.Tests
{
    public class ConnectionFactory : ILocalizationDbContext
    {
        private readonly SqlConnection _connection;

        public ConnectionFactory()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var path2 = GetType().Assembly.Location;
            _connection =
                new SqlConnection(string.Format(@"Server=.\SQLExpress;Integrated Security=True;Database=MvcContrib;",
                                                AppDomain.CurrentDomain.BaseDirectory));
                //.Replace("bin\\", "").Replace("Debug", "")
            _connection.Open();
        }

        #region ILocalizationDbContext Members

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public char ParameterPrefix
        {
            get { return '@'; }
        }

        public string ChangePrefix(string sql)
        {
            return sql;
        }

        #endregion
    }
}