using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
    public class DataAccess
    {
        protected string dbPath;
        
        public DataAccess(string initDbPath)
        {
            dbPath = initDbPath;
        }
    }
}
