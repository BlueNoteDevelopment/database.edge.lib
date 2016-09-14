﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using database.edge.lib.providers;
using System.Data.Odbc;


namespace database.edge.lib.tests.providers
{
    [TestClass]
    public class OdbcBaseProviderTest
    {
        [TestMethod]
        public void ExecuteSqlInvalidConnection()
        {
            string dsn = "InvalidDSNName";
            IDataBaseProvider db = OdbcProviderFactory.CreateOdbcProvider("DSN", dsn);

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
