using database.edge.lib.conversion;
using database.edge.lib.providers;
using database.edge.lib.utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib
{
    public class MsSqlConnector
    {
        public async Task<Object> Invoke(dynamic input)
        {
            object[] sqlparams = { };
            string database = "";
            string server = "";
            string user = "";
            string password = "";


            string command = "";
 


            if (DbHelper.IsPropertyExist(input, "database")) { database = (string)input.database; }
            if (DbHelper.IsPropertyExist(input, "server")) { server = (string)input.server; }
            if (DbHelper.IsPropertyExist(input, "user")) { user = (string)input.user; }
            if (DbHelper.IsPropertyExist(input, "password")) { password = (string)input.password; }

            if (DbHelper.IsPropertyExist(input, "command")) { command = (string)input.command; }
            
            try
            {
                sqlparams = (object[])input.@params;
            }
            catch (Exception) { }

            command = command.Trim();


            if (command.ToUpperInvariant().StartsWith("INSERT") ||
                command.ToUpperInvariant().StartsWith("UPDATE") ||
                command.ToUpperInvariant().StartsWith("DELETE"))
            {
                throw new InvalidOperationException("Only SELECT commands are Supported");
            }


            IDataBaseProvider db = DBProviderFactory.CreateDBProvider("MSSQL", "",user,password,database,server);

            if (db != null)
            {
                //TODO parse parameters and insert into tokensin command
                string sql = command;


                try
                {
                    DataTable dt = db.ExecuteSelectQuery(sql);
                    //Todo implement formats
                    return DataTableConverter.ConvertDataTableToRowCol(dt);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                catch (Exception)
                {
                    throw;
                }


            }
            else
            {
                throw new Exception("Provider Not Implemented");
            }
        }
    }
}
