using Microsoft.VisualStudio.TestTools.UnitTesting;
using database.edge.lib.providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.providers.Tests
{
    [TestClass()]
    public class OdbcProviderFactoryTests
    {
        [TestMethod()]
        public void CreateOdbcProviderInvalidProviderTest()
        {
            try
            {
                OdbcProviderFactory.CreateOdbcProvider("XXX");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
            
        }

        [TestMethod()]
        public void CreateOdbcProviderOfTypeDSNTest()
        {
            IDataBaseProvider db =  OdbcProviderFactory.CreateOdbcProvider("DSN","Test1");
            
            Assert.IsInstanceOfType(db, typeof(OdbcDSNDataProvider));
        }

        [TestMethod()]
        public void CreateOdbcProviderOfTypeFileTest()
        {
            IDataBaseProvider db = OdbcProviderFactory.CreateOdbcProvider("FILE", "C:\\temp\\file.dsn");

            Assert.IsInstanceOfType(db, typeof(OdbcFileDataProvider));
        }

        [TestMethod()]
        public void ValidateConnectionStringOfTypeFileTest()
        {
            string filePath = "C:\\temp\\file.dsn";
            IDataBaseProvider db = OdbcProviderFactory.CreateOdbcProvider("FILE", filePath);
            Assert.AreEqual(db.ConnectionString, "FILEDSN=" + filePath);
        }

        [TestMethod()]
        public void ValidateConnectionStringOfTypeDsnTest()
        {
            string dsn = "Test1";
            IDataBaseProvider db = OdbcProviderFactory.CreateOdbcProvider("DSN", dsn);
            Assert.AreEqual(db.ConnectionString, "DSN=" + dsn);
        }

    }
}