using System.Collections.Generic;

namespace PraktischeProefT4T.Classes
{
    public interface IPlanner
    {
        List<Talk> Track1 { get; }
        List<Talk> Track2 { get; }
        List<Talk> AllTalks { get; }

        bool MaakPlanning(List<Talk> talks);
        void AddUserRecord(string title, int duration);
        void ImportFromFile();
    }
}