﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("database.edge.lib.tests")]
namespace database.edge.lib.providers
{
    internal class BaseOdbcDataProvider
    {
        public string ConnectionString { get; internal set; }

        public DataTable ExecuteSelectQuery(string sql)
        {
            try
            {
                using (OdbcConnection cn = new OdbcConnection(ConnectionString))
                {
                    cn.Open();
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch(OdbcException)
            {
                throw;
            }
        }


    }
}
