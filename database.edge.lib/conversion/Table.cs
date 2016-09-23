using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.conversion
{
    public class Table
    {
        private List<Column> _cols;
        private List<Row> _rows;

        public Table()
        {
            _cols = new List<Column>();
            _rows = new List<Row>();
        }

        public List<Row> Rows
        {
            get{return _rows;}
        }

        public List<Column> Cols
        {
            get { return _cols; }
        }

    }
}
