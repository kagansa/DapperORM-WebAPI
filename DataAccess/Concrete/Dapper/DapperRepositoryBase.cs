using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccess.Concrete.Dapper
{
    public abstract class DapperRepositoryBase
    {
        protected string _connectionString;

        public DapperRepositoryBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }
    }
}