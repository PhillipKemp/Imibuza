using System.Web.Mvc;
using Imibuza.Domain;
using Imibuza.Services;
using Imibuza.Web.Models;
using Microsoft.AspNet.Identity;

namespace Imibuza.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        // GET: Question
        public JsonResult GetCategories()
        {
            var categoryService = new CategoryService();

            var categories = categoryService.GetAllCategories();

            var model = CategoriesModel.FromDomain(categories);

            return new JsonResult
            {
                Data = model
            };
        }

        public JsonResult Create(QuestionModel model)
        {
            var question = model.ToDomain();

            var questionService = new QuestionService();

            questionService.Create(question);

            return new JsonResult
            {
                Data = true
            };

        }


        public JsonResult GetNext()
        {
            var questionService = new QuestionService();

            var question = questionService.GetRandom();

            return new JsonResult
            {
                Data = question == null ? null : AskingQuestionModel.FromDomain(question)
            };
        }

        public JsonResult SubmitAnswer(SubmitModel model)
        {

            var userId = User.Identity.GetUserId();

            var questionService = new QuestionService();

            var submittedAnswer = new SubmittedAnswer()
            {
                QuestionId = model.Id,
                UserId = userId,
            };

            var correct = questionService.SubmitAnswer(submittedAnswer, model.Answer);

            return new JsonResult
            {
                Data = correct
            };
        }


    }




}