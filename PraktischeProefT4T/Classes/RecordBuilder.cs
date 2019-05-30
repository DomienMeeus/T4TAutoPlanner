using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
    public class RecordBuilder : IRecordBuilder
    {
        public Talk BuildRecord(string recordString)
        {
            int duration = ExtractTime(recordString);
            string title = ExtractTitle(recordString, duration);


            return new Talk(title, duration);
        }
        public List<Talk> BuildRecord(List<string> records)
        {
            List<Talk> output = new List<Talk>();
            foreach (string record in records)
            {
              output.Add(BuildRecord(record));
            }
            return output;
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
    }
}
