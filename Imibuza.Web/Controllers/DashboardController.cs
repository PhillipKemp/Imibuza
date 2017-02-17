using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Imibuza.Domain;
using Imibuza.Services;
using Imibuza.Web.Models;
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

        public JsonResult GetProfile()
        {
            var userId = User.Identity.GetUserId();

            var service = new QuestionService();

            var profile = service.GetProfile(userId);

            return new JsonResult
            {
                Data = ProfileModel.FromDomain(profile)
            };
        }
    }

   

   
}