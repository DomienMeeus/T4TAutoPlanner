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

            if((duration == -1)||(title == ""))
            {
                return null;
            }
            else
            {
                return new Talk(title, duration);
            }

           
        }
        public List<Talk> BuildRecord(List<string> records)
        {
            List<Talk> output = new List<Talk>();
            foreach (string record in records)
            {
                Talk talkObj = BuildRecord(record);
               if(talkObj != null)
                {
                    output.Add(talkObj);
                }
                 
                
              
            }
            return output;
        }
        private static int ExtractTime(string input)
        {
            try
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
                throw new Exception("Talk has an invalid time fromat. Use min of lighting");
            }
            catch (Exception timeExtr)
            {
                return  -1;
                throw timeExtr;

            }
            

        }

        private static string ExtractTitle(string input, int duration)
        {
            string output;
            
                 
                
                if (duration <= 5)
                {
                   output = input.Replace("lightning", "");
                }
                else
                {
                    output = input.Replace($"{duration}min", "");
                }

            return output;
            
            
            
        }

        
    }
}
