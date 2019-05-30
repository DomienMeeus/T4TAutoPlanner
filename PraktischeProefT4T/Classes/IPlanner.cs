using System.Collections.Generic;

namespace PraktischeProefT4T.Classes
{
    public interface IPlanner
    {
        List<Talk> Track1 { get; }
        List<Talk> Track2 { get; }
        List<Talk> AllTalks { get; }

        bool MaakPlanning();
        void AddUserRecord(string userInput);
        void ImportFromFile();
    }
}