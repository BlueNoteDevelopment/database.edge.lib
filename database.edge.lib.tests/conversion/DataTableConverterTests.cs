using Microsoft.VisualStudio.TestTools.UnitTesting;
using database.edge.lib.conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace database.edge.lib.conversion.Tests
{
    [TestClass()]
    public class DataTableConverterTests
    {
        DataTable _dt = null;


        [TestInitialize]
        public void Init()
        {
            _dt = new DataTable();
            _dt.Columns.Add(new DataColumn("Name", typeof(String)));
            _dt.Columns.Add(new DataColumn("Number", typeof(Decimal)));
            _dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));

            _dt.Rows.Add(new object[] { "Seth", 42, new DateTime(1974, 3, 14) });
            _dt.Rows.Add(new object[] { "Andy", 37, new DateTime(1979, 5, 28) });
            _dt.Rows.Add(new object[] { "Hilary", 35, new DateTime(1981, 9, 10) });

        }

        [TestCleanup]
        public void TearDown()
        {
            if (_dt != null) { _dt.Dispose(); }
            _dt = null;
        }

        [TestMethod()]
        public void ConvertDataTableToRowColTest()
        {
            Table t = DataTableConverter.ConvertDataTableToRowCol(_dt);

            Assert.AreEqual(t.Cols.Count, _dt.Columns.Count);
            Assert.AreEqual(t.Rows.Count, _dt.Rows.Count);

        }

        [TestMethod()]
        public void ConvertDataTableToJSONTest()
        {
            String json = DataTableConverter.ConvertDataTableToJSON(_dt);

            Assert.IsTrue(String.IsNullOrEmpty(json) == false);


        }
    }
}