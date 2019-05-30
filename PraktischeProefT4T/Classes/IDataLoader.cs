using System.Collections.Generic;

namespace PraktischeProefT4T.Classes
{
    public interface IDataLoader
    {
        List<Talk> Records { get; }

        
        List<Talk> ImportAllData();
    }
}