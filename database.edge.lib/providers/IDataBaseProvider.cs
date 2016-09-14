using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.providers
{
    public interface IDataBaseProvider
    {
        string ConnectionString { get; }
        System.Data.DataTable ExecuteSelectQuery(string sql);
    }
}
