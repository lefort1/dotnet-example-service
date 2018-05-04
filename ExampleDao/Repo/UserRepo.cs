using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Dapper;
using DataAccess.Connection;
using Models;

namespace ExampleDao.Repo
{
    public class UserRepo
    {
        private const string TableName = "User";
        private readonly IDatabaseConnection _dbConnection;

        public UserRepo(IDatabaseConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public IEnumerable<User> SelectAll()
        {
            return WithConnection(connection => connection.Query<User>($"select * from {TableName}"));
        }

        public User SelectById(int id)
        {
            return WithConnection(connection =>
                    connection.Query<User>($"select * from {TableName} where User.EmployeeId = {id}"))
                .First();
        }

        public void AddUser(User user)
        {
            String sqlStatement =
                $"Insert into {TableName} (FirstName, LastName, Email, Role) " +
                $"values ({user.FirstName}, {user.LastName}, {user.Email}, {user.Role}";
            
            WithConnection(connection =>
                connection.Query<User>(sqlStatement));
        }

        public void DeleteUserById(int id)
        {
            String sqlStatement = $"Delete * from {TableName} where EmployeeId = {id}";
            WithConnection(connection => connection.Query(sqlStatement));
        }

        private R WithConnection<R>(Func<IDbConnection, R> toRun)
        {
            using (IDbConnection connection = this._dbConnection.GetConnection())
            {
                return toRun(connection);
            }
        }
    }
}