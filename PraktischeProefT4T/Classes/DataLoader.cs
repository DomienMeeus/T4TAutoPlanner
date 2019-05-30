using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace PraktischeProefT4T.Classes
{
   public class DataLoader : DataAccess, IDataLoader
    {
        private List<Talk> records = new List<Talk>();
        public List<Talk> Records { get => records;  }
        public DataLoader(string initDbPath)
            : base(initDbPath)
        {
            
           dbPath = BuildPath(initDbPath);
            ImportAllData();
        }

        public List<Talk> ImportAllData()
        {
            records.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(dbPath)) {
                    while (!reader.EndOfStream)
                    {
                        string record = reader.ReadLine();
                        records.Add(BuildRecord(record));

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
        private Talk BuildRecord(string input)
        {
            int duration = ExtractTime(input);
            string title = ExtractTitle(input, duration);


            return new Talk(title, duration);
        }
        private static int ExtractTime(string input)
        {
            string[] record = input.Split(' ');

            foreach (string word in record)
            {
                if (word.Contains("min"))
                {
                    string timeStr = word.Replace("min", "");
                    int timeInt;
                    if (Int32.TryParse(timeStr, out timeInt))
                    {
                        return timeInt;
                    }
                }
                else if (word == "lightning")
                {
                    return 5;
                }
            }
            return 0;

        }
        
        private string ExtractTitle(string input, int duration)
        {
            if (duration == 5)
            {
                return input.Replace("lightning", "");
            }
            else
            {
                return input.Replace($"{duration}min", "");
            }
        }

        private string BuildPath(string path)
        {
            string dir = Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().Location);

            return dir + dbPath;
        }
    }
}
