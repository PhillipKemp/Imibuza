using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Imibuza.Domain;

namespace Imibuza.Web.Models
{
    public class TimelineEntryModel
    {
        public string Question { get; set; }
        public bool Correct { get; set; }
        public string CompletedOn { get; set; }

        public static TimelineEntryModel FromDomain(TimelineEntry timelineEntry)
        {
            return new TimelineEntryModel
            {
                Question = timelineEntry.Question,
                Correct = timelineEntry.Correct,
                CompletedOn = timelineEntry.CompletedOn.ToString("dd MMMM yy")
            };
        }
    }
}