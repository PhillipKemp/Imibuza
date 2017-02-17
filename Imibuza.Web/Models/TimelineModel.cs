using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Imibuza.Domain;

namespace Imibuza.Web.Models
{
    public class TimelineModel
    {
        public static TimelineModel FromDomain(Timeline timeline)
        {
            return new TimelineModel
            {
                Entries = timeline.Entries.Select(TimelineEntryModel.FromDomain).ToList()
            };
        }

        public List<TimelineEntryModel> Entries { get; set; }
    }
}