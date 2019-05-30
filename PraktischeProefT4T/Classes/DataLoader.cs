using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Autofac;

namespace PraktischeProefT4T.Classes
{
   public class DataLoader : DataAccess, IDataLoader
    {
        private List<string> records;
        public List<string> Records { get => records;  }
        public DataLoader():base()
        {
            records = new List<string>();
        }

        public List<string> ImportAllData()
        {
            records.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(dbPath)) {
                    while (!reader.EndOfStream)
                    {
                        string record = reader.ReadLine();
                        records.Add(record);

                    }
                } 
                
                return Records;
            }
            catch (Exception)
            {

                MessageBox.Show("Data import failed");
                return records;


            }
            

        }
       

      
    }
}
