using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.providers
{
    internal class OdbcFileDataProvider : BaseOdbcDataProvider, IDataBaseProvider
    {
        public OdbcFileDataProvider(string filename)
        {
            ConnectionString = "FILEDSN=" + filename;
        }

        public OdbcFileDataProvider(string filename, string user, string password)
        {
            ConnectionString = "FILEDSN=" + filename;

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
