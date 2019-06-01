using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
    public  class PresentationFormatter : IPresentationFormatter
    {
        public  List<string> RecordsToStrings(List<Talk> talks)
        {
            List<string> recordsStrings = new List<string>();
            foreach (Talk talk in talks)
            {
                TimeSpan result = TimeSpan.FromMinutes(talk.StartTime);
                string recordsToStrings;
                string TimeString = result.ToString("hh':'mm");
                if (talk.Duration == 5)
                {
                    recordsToStrings = $"{TimeString}{talk.TimePrefix} {talk.Title} lightning  ";

                }
                else if (talk.Duration == 0)
                {
                    recordsToStrings = $"{TimeString}{talk.TimePrefix} {talk.Title}";
                }
                else
                {
                    recordsToStrings = $"{TimeString}{talk.TimePrefix} {talk.Title} {talk.Duration}min";

                }
                recordsStrings.Add(recordsToStrings);

            }
            return recordsStrings;




        }
        public  List<string> RecordsToStrings(List<Talk> talks, bool showTime)
        {
            List<string> recordsStrings = new List<string>();

            foreach (Talk talk in talks)
            {
                string prefix;
                string timeString;
                string recordsToStrings;
                if (showTime)
                {
                    TimeSpan result = TimeSpan.FromMinutes(talk.StartTime);

                    timeString = result.ToString("hh':'mm");
                    prefix = talk.TimePrefix;
                }
                else
                {
                    timeString = "";
                    prefix = "";
                    
                }

                if (talk.Duration == 5)
                {
                    recordsToStrings = $"{timeString}{prefix} {talk.Title} lightning  ";

                }
                else if (talk.Duration == 0)
                {
                    recordsToStrings = $"{timeString}{prefix} {talk.Title}";
                }
                else
                {
                    recordsToStrings = $"{timeString}{prefix} {talk.Title} {talk.Duration}min";

                }
                recordsStrings.Add(recordsToStrings);

            }
            return recordsStrings;




        }
    }
}
