using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("database.edge.lib.tests")]
namespace database.edge.lib.providers
{
    internal class MSSQLServerDataProvider : IDataBaseProvider
    {
        public string ConnectionString { get; internal set; }

        public DataTable ExecuteSelectQuery(string sql)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MSSQLServerDataProvider(string server, string database, string user, string password)
        {
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

            user = user.Trim();
            password = password.Trim();
            server = server.Trim();

            if (String.IsNullOrWhiteSpace(server))
            {
                server = ".";
            }
            connection.InitialCatalog = database;
            connection.DataSource = server;

        
            if((!String.IsNullOrWhiteSpace(user) && !String.IsNullOrWhiteSpace(password)))
            {
                connection.IntegratedSecurity = false;
                connection.UserID = user;
                connection.Password = password;
            }else
            {
                connection.IntegratedSecurity = true;
            }

            this.ConnectionString = connection.ToString();
        }

    }
}
