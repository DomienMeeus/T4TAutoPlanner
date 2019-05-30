using System.Collections.Generic;

namespace PraktischeProefT4T.Classes
{
    public interface IPlanner
    {
        List<Talk> Track1 { get; }
        List<Talk> Track2 { get; }

        bool MaakPlanning();
    }
}