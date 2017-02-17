using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imibuza.Domain
{
    public class TimelineEntry
    {
        public string Question { get; set; }
        public bool Correct { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}
