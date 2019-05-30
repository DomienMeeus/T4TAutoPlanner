using System.Collections.Generic;

namespace PraktischeProefT4T.Classes
{
    public interface IRecordBuilder
    {
        Talk BuildRecord(string recordString);
        List<Talk> BuildRecord(List<string> recordStrings);
    }
}