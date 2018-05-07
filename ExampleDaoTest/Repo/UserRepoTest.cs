using System.IO;
using DataAccess.Connection;
using ExampleDao.Connection;
using ExampleDao.Repo;
using Xunit;
using Xunit.Abstractions;

namespace ExampleDaoTest.Repo
{
    public class UnitTest1
    {
        private ITestOutputHelper output;

        static string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        static string databasePath = solutiondir + "/../../ExampleDao/Resources/testDatabase.db";

        private static IDatabaseConnection _database = DatabaseConnectionFactory.sqliteDb(databasePath);
        private static UserRepo _repo = new UserRepo(_database);


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
            var result = _repo.SelectById(1);

            Assert.Equal(1, result.EmployeeId);
            Assert.Equal("Jonathan", result.FirstName);
            Assert.Equal("Jos", result.LastName);
            Assert.Equal("test@mail.com", result.Email);
            Assert.Equal("Bad Programmer", result.Role);
        }
    }
}