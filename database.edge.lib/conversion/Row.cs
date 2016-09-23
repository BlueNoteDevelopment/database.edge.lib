using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.conversion
{
    public class Row
    {
        private List<object> _values;
        public List<object> Values
        {
            get
            {
                if (_values == null){_values = new List<object>();}
                return _values;
            }
        }


        public Row()
        {
            _values = new List<object>();
        }


        public Row(IEnumerable<object> ItemArray)
        {
            _values = new List<object>();
            _values.AddRange(ItemArray);
        }

    }
}
