using System.Data;
using System.Data.SqlClient;

namespace Zensar.Core.DAL.Interfaces
{
    public interface IQueryManager
    {
        string CommandText { get; set; }
        CommandType CommandType { get; set; }
        SqlParameter[] SqlParameters { get; set; }
        DataTable ExecuteDataTable();
    }
}