using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database.edge.lib.providers;
using database.edge.lib.utility;
using System.Data;
using database.edge.lib.conversion;

namespace database.edge.lib
{
    public class OdbcConnector
    {

    //    var odbc = {
    //    dsn:'Test1',
    //    command:'SELECT * FROM Users WHERE Active={1}',
    //    params:[{value:'1'}]
    //};


    public async Task<Object> Invoke(dynamic input)
        {
            object[] sqlparams = { };
            string dsn = "";
            string command = "";
            string table = "";


            if (DbHelper.IsPropertyExist(input, "dsn")){dsn = (string)input.dsn;}
            if (DbHelper.IsPropertyExist(input, "command")){command = (string)input.command;}
            if (DbHelper.IsPropertyExist(input, "table")) { table = (string)input.table; }

            try
            {
                sqlparams = (object[])input.@params;
            }catch (Exception) { }

            command = command.Trim();
            table = table.Trim();

            if (String.IsNullOrWhiteSpace(command) && !String.IsNullOrWhiteSpace(table))
            {
                command = "SELECT * FROM " + table;
            }

            if (command.ToUpperInvariant().StartsWith("INSERT") ||
                command.ToUpperInvariant().StartsWith("UPDATE") ||
                command.ToUpperInvariant().StartsWith("DELETE"))
            {
                throw new InvalidOperationException("Only SELECT commands are Supported");
            }


            IDataBaseProvider db =   DBProviderFactory.CreateDBProvider("DSN", dsn);

            if (db != null)
            {
                //TODO parse parameters and insert into tokensin command
                string sql = command;
                DataTable dt  = db.ExecuteSelectQuery(sql);

                //Todo implement formats

                return DataTableConverter.ConvertDataTableToRowCol(dt);

            }else
            {
                throw new Exception("Provider Not Implemented");
            }

        }





    }
}
