using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Xml.Linq;
using DataAccess.Connection;
using Microsoft.Data.Sqlite;
using Xunit.Abstractions;

namespace ExampleDao.Connection
{
    public class DatabaseConnectionFactory
    {
        private static Assembly _assembly;
        private static StreamReader _textStreamReader;

        public static IDatabaseConnection sqliteDb(string databasePath)
        {
            try
            {
                return new SqliteConn($"Data Source={databasePath}");
            }
            catch (Exception e)
            {
                throw new Exception("Failed to get SqliteDb resource", e);
            }
        }
    }

    public class SqliteConn : IDatabaseConnection
    {
        private string _dbConnection;

        public SqliteConn(string dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public IDbConnection GetConnection()
        {
            return new SqliteConnection(this._dbConnection);
        }
    }

    public class InMemoryConnection : IDatabaseConnection
    {
        public IDbConnection GetConnection()
        {
            return new SqliteConnection("Data Source=:memory:?cache=shared");
        }
    }
}