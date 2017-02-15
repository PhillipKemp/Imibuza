using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Imibuza.Web.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public JsonResult GetNext()
        {
            return new JsonResult();
        }

        public JsonResult SubmitAnswer()
        {
            return new JsonResult
            {
                Data = true
            };
        }


    }
}