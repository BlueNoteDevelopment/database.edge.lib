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

            if (OdbcHelper.IsPropertyExist(input, "dsn")){dsn = (string)input.dsn;}
            if (OdbcHelper.IsPropertyExist(input, "command")){command = (string)input.command;}

            try
            {
                sqlparams = (object[])input.@params;
            }catch (Exception) { }

            IDataBaseProvider db =   OdbcProviderFactory.CreateOdbcProvider("DSN", dsn);

            if (db != null)
            {
                //TODO parse parameters and insert into tokensin command
                string sql = command;
                DataTable dt  = db.ExecuteSelectQuery(sql);

                //Todo implement formats

                return DataTableConverter.ConvertDataTableToJSON(dt);

            }else
            {
                throw new Exception("Provider Not Implemented");
            }

        }





    }
}
