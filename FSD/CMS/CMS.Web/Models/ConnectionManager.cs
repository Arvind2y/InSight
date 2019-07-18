using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class ConnectionManager
    {
        private string GetConnectionString()
        {
            string connectionString = string.Empty;
            //var connection = ConfigurationManager.
            //    //.Cast<ConnectionStringSettings>()
            //              //.Where(p => p.LockItem == false).FirstOrDefault();
            //connectionString = connection != null ? connection.ConnectionString : string.Empty;
            return connectionString;
        }


        private SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public SqlConnection Connection
        {
            get
            {
                return GetConnection();
            }
        }
    }
}
