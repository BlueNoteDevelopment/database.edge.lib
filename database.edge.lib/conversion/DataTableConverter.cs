using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace database.edge.lib.conversion
{
    public class DataTableConverter
    {
        public static Table ConvertDataTableToRowCol(DataTable dt)
        {
            Table table = new Table();

            foreach(DataColumn dc in dt.Columns)
            {
                table.Cols.Add(new Column() { Name = dc.Caption, DataType = dc.DataType.ToString() });
            }

            foreach(DataRow dr in dt.Rows)
            {
                table.Rows.Add(new Row(dr.ItemArray));
            }

            return table;
        }

        public static string ConvertDataTableToJSON(DataTable dt)
        {
            return JsonConvert.SerializeObject(ConvertDataTableToRowCol(dt));
        }



    }
}
