using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
    public class Planner : IPlanner
    {
        private Track afternoonTrack1;
        private Track afternoonTrack2;
        private Track morningTrack1;
        private Track morningTrack2;
        private List<Talk> unplannedTalks;
        private List<Talk> removedTalks;
        private List<Talk> allTalks;
        private List<Track> allTracks;
        private int counter;
        private int maxCounter;
        private IDataLoader dataloader;
        private IRecordBuilder recordBuilder;


        public List<Talk> Track1 { get => MakeDayTrack(morningTrack1, afternoonTrack1); }
        public List<Talk> Track2 { get => MakeDayTrack(morningTrack2, afternoonTrack2); }
        public List<Talk> AllTalks { get => allTalks; set=> allTalks = value; }
        public int TotalTalkTime { get => allTalks.Select(x => x.Duration).Sum(); }
        public int MaxTalkTime { get => allTracks.Select(x => x.MaxTime).Sum(); }
        public int RemainingTime { get => MaxTalkTime - TotalTalkTime; }
        public Planner(IDataLoader initDatLoader, IRecordBuilder initRecordBuilder, Track initMorningTrack, Track initAfternoonTrack)
        {
            dataloader = initDatLoader;
            recordBuilder = initRecordBuilder;
            afternoonTrack1 = new Track(initAfternoonTrack.MaxTime, initAfternoonTrack.MinTime);
            afternoonTrack2 = new Track(initAfternoonTrack.MaxTime, initAfternoonTrack.MinTime);
            morningTrack1 = new Track(initMorningTrack.MaxTime);
            morningTrack2 = new Track(initMorningTrack.MaxTime);
            removedTalks = new List<Talk>();
            allTalks = new List<Talk>();
            allTracks = new List<Track>()
           {
               afternoonTrack1,
               afternoonTrack2,
               morningTrack1,
               morningTrack2
           };
            maxCounter = 100;

        }
        public bool MaakPlanning(List<Talk> talks)
        {
            ClearAllTracks();
            if (BerekenPlanning(talks))
            {
                return true ;
            }

            return false;

            

        }
        private bool BerekenPlanning(List<Talk> talks)
        {
            if (counter < maxCounter) {
                unplannedTalks = SortTalks(ClearTalks(talks));

                BerekenTrack(morningTrack1, out morningTrack1);
                BerekenTrack(morningTrack2, out morningTrack2);
                BerekenTrack(afternoonTrack1, out afternoonTrack1);
                BerekenTrack(afternoonTrack2, out afternoonTrack2);
                if (!CheckIfComplete())
                {
                    counter++;
                    BerekenPlanning(unplannedTalks);
                }
            }
            else
            {
                return false;
            }
            return true;
            
        }
        public void ImportFromFile()
        {
            List<Talk> importedTalks = recordBuilder.BuildRecord(dataloader.ImportAllData());
           if (importedTalks.Select(x => x.Duration).Sum() <= RemainingTime)
            {
                allTalks.AddRange(importedTalks);
            }
            else
            {
                throw new Exception("Total duration of imported talks is to large.");
            }

            
        }
        public void AddUserRecord(string title, int duration)
        {
            try
            {
                if(duration<= RemainingTime)
                {
                    allTalks.Add(new Talk(title ,duration));
                }
                else
                {
                    throw new Exception("Duration is to long.");
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            
           
            
            

        }

        private bool CheckIfComplete()
        {
            if (unplannedTalks.Count() == 0
                &&
                 morningTrack1.MinTimeReached
                &&
                 morningTrack2.MinTimeReached
                &&
                 afternoonTrack1.MinTimeReached
                &&
                 afternoonTrack2.MinTimeReached) {
                return true;
            }
            else
            {
                return false;
            }


        }
        private List<Talk> ClearTalks(List<Talk> talks) {
           
            foreach (Talk talk in talks)
            {
                talk.StartTime = 0;
                talk.TimePrefix = "";
            }
            return talks;

        }


        private List<Talk> MakeDayTrack(Track morning, Track afternoon)
        {
            
            
            List<Talk> dayTrack = new List<Talk>(morning.Talks);
            Talk lunch = new Talk("Lunch", 60);
            lunch.TimePrefix = "PM";
            lunch.StartTime = 12 * 60;
            dayTrack.Add(lunch);
            dayTrack.AddRange(afternoon.Talks);
            Talk networking = new Talk("Networking Event", 0);
            networking.TimePrefix = "PM";
            networking.StartTime = afternoon.StartTime + afternoon.CurrentTime;
            dayTrack.Add(networking);
            return dayTrack;
        }
     

        private void ClearAllTracks()
        {
            foreach (Track track in allTracks)
            {
                track.CurrentTime = 0;
                track.Talks.Clear();
                
            }
           

        }
        private void BerekenTrack(Track track, out Track  plannedTrack)
        {

               
                Track newTrack = track;
                if (!CheckFull(track))
                {
                    bool talkAdded = false;
                    for (int talkCounter = 0; talkCounter < unplannedTalks.Count; talkCounter++)
                    {
                        if (AddTalk(unplannedTalks[talkCounter], track, out newTrack))
                        {
                            talkAdded = true;
                            break;
                        }
                    }
                    if (!talkAdded)
                    {
                        track = RemoveLastTalk(newTrack);
                    }
                    

                }
                track = newTrack;


            
            
            if (track.MinTimeReached)
            {
                plannedTrack = track;
                unplannedTalks.AddRange(removedTalks);
                removedTalks.Clear();
                SortTalks(unplannedTalks);
                
               
            }
            else
            {
                BerekenTrack(track, out plannedTrack);
            }
            
           
        }
       
        private List<Talk> SortTalks(List<Talk> talks)
        {
            List<Talk> sortedList = talks.OrderByDescending(o => o.Duration).ToList();
                return sortedList;
        }
        private Track RemoveLastTalk(Track input)
        {
            Talk lastAdded = input.Talks.Last<Talk>();
            input.CurrentTime -= lastAdded.Duration;
            removedTalks.Add(lastAdded);
            input.Talks.Remove(lastAdded);
            return input;
        }
        private bool AddTalk(Talk talk, Track track, out Track newTrack)
        {
            if (talk.Duration + track.CurrentTime <= track.MaxTime)
            {
                talk.StartTime = track.CurrentTime + track.StartTime;
                talk.TimePrefix = track.TimePrefix;

                track.Talks.Add(talk);
                unplannedTalks.Remove(talk);
                track.CurrentTime += talk.Duration;
                track.IsFull = CheckFull(track);
                newTrack = track;
               
                return true;
            }
            newTrack = track;
            
            return false;
        }
        private bool CheckFull(Track track)
        {
            if (track.CurrentTime == track.MaxTime)
            {
                return  true;
            }
            return false;
        }
       
    }
}
