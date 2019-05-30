using System.Collections.Generic;

namespace PraktischeProefT4T.Classes
{
    public interface IDataLoader
    {
        List<string> Records { get; }

        
        List<string> ImportAllData();
    }
}