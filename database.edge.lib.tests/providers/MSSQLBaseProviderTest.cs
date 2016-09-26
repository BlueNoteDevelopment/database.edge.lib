using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using database.edge.lib.providers;
using System.Data.SqlClient;

namespace database.edge.lib.tests.providers
{
    [TestClass]
    public class MSSQLBaseProviderTest
    {
        [TestMethod]
        public void CreateMSSQLProviderIntegratedSecurity()
        {

            MSSQLServerDataProvider db = new MSSQLServerDataProvider(".", "Test", "", "");

            Assert.IsTrue(db.ConnectionString.Contains("Integrated Security=True"));
        }

        [TestMethod]
        public void CreateMSSQLProviderIntegratedSecurityWithPassword()
        {

            MSSQLServerDataProvider db = new MSSQLServerDataProvider(".", "Test", "", "Derp");
            System.Diagnostics.Debug.WriteLine(db.ConnectionString);

            Assert.IsTrue(db.ConnectionString.Contains("Integrated Security=True"));
        }

        [TestMethod]
        public void CreateMSSQLProviderIntegratedSecurityWithUser()
        {

            MSSQLServerDataProvider db = new MSSQLServerDataProvider(".", "Test", "Derp", "");
            System.Diagnostics.Debug.WriteLine(db.ConnectionString);

            Assert.IsTrue(db.ConnectionString.Contains("Integrated Security=True"));
        }

        [TestMethod]
        public void CreateMSSQLProviderSqlSecurity()
        {

            MSSQLServerDataProvider db = new MSSQLServerDataProvider(".", "Test", "TheUser", "ThePassword");
            System.Diagnostics.Debug.WriteLine(db.ConnectionString);
            //"Data Source=.;Initial Catalog=Test;Integrated Security=False;User ID=TheUser;Password=ThePassword"

            Assert.IsTrue(db.ConnectionString.Contains("Integrated Security=False"));
            Assert.IsTrue(db.ConnectionString.Contains("User ID=TheUser"));
            Assert.IsTrue(db.ConnectionString.Contains("Password=ThePassword"));

        }

        [TestMethod]
        public void ExecuteSqlValidConnection()
        {
            IDataBaseProvider db = DBProviderFactory.CreateDBProvider("MSSQL","","","","KomodoTest",".");

            try
            {
                db.ExecuteSelectQuery("SELECT * FROM Users");
                Assert.IsTrue(true);
            }
            catch (SqlException odbcEx)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }


    }
}
