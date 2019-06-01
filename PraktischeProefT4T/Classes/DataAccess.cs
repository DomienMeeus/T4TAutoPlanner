using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PraktischeProefT4T.Classes
{
    public class DataAccess
    {
        protected string dbPath;
        
        public DataAccess()
        {
            dbPath = BuildPath(@"\..\..\Data\EventData.txt");
        }
        private string BuildPath(string path)
        {   //Build the path to the data file
            string dir = Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().Location);

            return dir + path;
        }
    }
}
