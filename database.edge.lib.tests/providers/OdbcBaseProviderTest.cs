using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using database.edge.lib.providers;
using System.Data.Odbc;


namespace database.edge.lib.tests.providers
{
    [TestClass]
    public class OdbcBaseProviderTest
    {
        private string _testDsn = "Test1";

        [TestMethod]
        public void ExecuteSqValidDSNConnection()
        {
            IDataBaseProvider db = DBProviderFactory.CreateDBProvider("DSN", _testDsn);

            try
            {
                db.ExecuteSelectQuery("SELECT * FROM Users");
                Assert.IsTrue(true);
            }
            catch (OdbcException odbcEx)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }




        [TestMethod]
        public void ExecuteSqlInvalidDSNConnection()
        {
            string dsn = "InvalidDSNName";
            IDataBaseProvider db = DBProviderFactory.CreateDBProvider("DSN", dsn);

            try
            {
                db.ExecuteSelectQuery("Null Query");
                Assert.Fail();
            }
            catch (OdbcException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }


        }
    }
}
