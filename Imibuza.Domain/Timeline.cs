using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imibuza.Domain
{
    public class Timeline
    {
        public Timeline()
        {
            Entries = new List<TimelineEntry>();
        }

        public List<TimelineEntry> Entries { get; set; }
    }
}
