using System.Data;

namespace DataAccess.Connection
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}