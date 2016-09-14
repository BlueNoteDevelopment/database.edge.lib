using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("database.edge.lib.tests")]
namespace database.edge.lib.providers
{
    internal class OdbcProviderFactory
    {
        private const string DSN = "DSN";
        private const string FILE = "FILE";

        public static IDataBaseProvider CreateOdbcProvider(string provider, string DsnOrFileName = "", string user = "", string password="",string database = "",string server="")
        {

            switch (provider.Trim().ToUpper())
            {
                case DSN:
                    return new OdbcDSNDataProvider(DsnOrFileName, user, password);
                case FILE:
                    return new OdbcFileDataProvider(DsnOrFileName, user,password);
                 default:
                    throw new ArgumentException("Invalid Provider Name");
            }

            throw new NotImplementedException();
        }


    }
}
