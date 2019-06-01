using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
   public class Talk 
    {
        private int id;
        static int count = 0;
        private int duration;
        private string title;
        private int startTime;
        private string timePrefix;
        
        public int Id { get => id; }
        public int Duration { get => duration; }
        public string Title { get => title;  }
        public int StartTime { get => startTime; set => startTime = value; }
        public string TimePrefix { get => timePrefix; set => timePrefix = value; }
        

        public Talk(string initTitle, int initDuration)
        {
            
            duration = initDuration;
            title = initTitle;
            id = count;
            count++;
        }

       
        
        
    }
}
