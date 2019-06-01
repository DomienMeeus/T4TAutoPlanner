using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
    interface IPresentationFormatter
    {
        List<string> RecordsToStrings(List<Talk> talks);


        List<string> RecordsToStrings(List<Talk> talks, bool showTime);

    }
}