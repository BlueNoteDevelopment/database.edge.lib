using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.edge.lib.utility
{
    public class DbHelper
    {
        public static bool IsPropertyExist(dynamic settings, string name)
        {

            if(settings is ExpandoObject){
                return ((IDictionary<string, object>)settings).ContainsKey(name);
            }
            else
            {
                return settings.GetType().GetProperty(name) != null;
            }

            
        }
    }
}
