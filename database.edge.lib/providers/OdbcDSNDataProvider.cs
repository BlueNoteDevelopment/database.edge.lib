using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.providers
{
    internal class OdbcDSNDataProvider : BaseOdbcDataProvider, IDataBaseProvider
    {

        public OdbcDSNDataProvider(string dsn)
        {
            ConnectionString = "DSN=" + dsn;

        }

        public OdbcDSNDataProvider(string dsn, string user,string password)
        {
            ConnectionString = "DSN=" + dsn;

            if (!string.IsNullOrWhiteSpace(user))
            {
                if (!string.IsNullOrWhiteSpace(password))
                {
                    ConnectionString += ";Uid=" + user + ";Pwd=" + password;
                }
                else
                {
                    throw new ArgumentException("Missing Password for Supplied User");
                }
            }
        }
        
    }
}
