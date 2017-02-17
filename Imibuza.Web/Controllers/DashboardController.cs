using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Imibuza.Domain;
using Imibuza.Services;
using Microsoft.AspNet.Identity;

namespace Imibuza.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public JsonResult GetTimeline()
        {
            var userId =  User.Identity.GetUserId();

            var service = new QuestionService();

            var timeline = service.GetTimeline(userId);

            var model = TimelineModel.FromDomain(timeline);

            return new JsonResult
            {
                Data = model
            };
        }
    }

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

    public class TimelineEntryModel
    {
        public string Question { get; set; }
        public bool Correct { get; set; }
        public DateTime CompletedOn { get; set; }

        public static TimelineEntryModel FromDomain(TimelineEntry timelineEntry)
        {
            return new TimelineEntryModel
            {
               Question = timelineEntry.Question,
               Correct = timelineEntry.Correct,
               CompletedOn = timelineEntry.CompletedOn
            };
        }
    }
}