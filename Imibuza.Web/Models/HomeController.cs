using System.Web.Mvc;

namespace Imibuza.Web.Models
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two()
        {
            return View();
        }

        public ActionResult Three()
        {
            return View();
        }

        public JsonResult CreateQuestion(QuestionModel model)
        {
            return new JsonResult();
        }
    }
}