using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
   public  class Track 
    {

        private int maxTime ;
        
        private int currentTime;
        private int startTime;
        private List<Talk> talks;      
        private bool isFull;
       
        private int minTime;
        private bool isMorning;

        public Track(int initMaxMorningTime)
        {
            maxTime = initMaxMorningTime;
            startTime = 9 * 60;
            isMorning = true;
            currentTime = 0;
            isFull = false;
            talks = new List<Talk>();
            minTime = initMaxMorningTime;
           
        }
        public Track(int initMaxAfternoonTime, int initMinAfternoonTime)
        {
            maxTime = initMaxAfternoonTime;
            minTime = initMinAfternoonTime;
            startTime = 60;
            isMorning = false;
            currentTime = 0;
            isFull = false;
            talks = new List<Talk>();
           
           

        }
      


        public List<Talk>Talks { get => talks; }
        public bool IsFull { get => isFull; set => isFull = value; }
        
        public int StartTime { get => startTime;}
        public int CurrentTime { get => currentTime; set => currentTime = value; }
        public string TimePrefix { get => isMorning ? "AM" : "PM"; }
        public int MaxTime { get => maxTime; }
        public bool IsMorning { get => isMorning;  }
        public bool MinTimeReached { get => currentTime>= minTime ; }
        public int MinTime { get => minTime; }
    }
}
