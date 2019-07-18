using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    interface IConnection
    {
        SqlConnection Connection { get; }
    }

    public interface ICommand
    {
        string CommandText  // For Inline Sql
        { get; set; }
        string SpName
        { get; set; }
        List<SqlParameter> SqlParams { get; set; }
        bool Execute();
        DataSet SelectData();
    }
}
