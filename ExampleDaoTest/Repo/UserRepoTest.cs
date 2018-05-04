using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using DataAccess.Connection;
using ExampleDao.Connection;
using ExampleDao.Repo;
using Models;
using Xunit;
using Xunit.Abstractions;

namespace ExampleDaoTest.Repo
{
    public class UnitTest1
    {
        private ITestOutputHelper output;
        private static IDatabaseConnection database;


        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

//        [Fact]
//        public void SelectAll()
//        {
//            string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
//            string databasePath = solutiondir + "/../../ExampleDao/Resources/testDatabase.db";
//
//            database = DatabaseConnectionFactory.sqliteDb(databasePath);
//            var results = new UserRepo(database).SelectAll().AsList();
//            Assert.Equal(1, results.Count);
//
//            var result = results[0];
//            Assert.Equal(1, result.EmployeeId);
//            Assert.Equal("Jonathan", result.FirstName);
//            Assert.Equal("Jos", result.LastName);
//            Assert.Equal("test@mail.com", result.Email);
//            Assert.Equal("Bad Programmer", result.Role);
//        }

        [Fact]
        public void selectById()
        {
            string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string databasePath = solutiondir + "/../../ExampleDao/Resources/testDatabase.db";
            
            database = DatabaseConnectionFactory.sqliteDb(databasePath);
            var result = new UserRepo(database).SelectById(1);
            
            Assert.Equal(1, result.EmployeeId);
            Assert.Equal("Jonathan", result.FirstName);
            Assert.Equal("Jos", result.LastName);
            Assert.Equal("test@mail.com", result.Email);
            Assert.Equal("Bad Programmer", result.Role);
        }

        [Fact]
        public void AddAndDeleteUser()
        {
            
        }
    }
}