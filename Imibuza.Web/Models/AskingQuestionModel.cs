using System;
using System.Collections.Generic;
using System.Linq;
using Imibuza.Domain;

namespace Imibuza.Web.Models
{
    public class AskingQuestionModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }

        public static AskingQuestionModel FromDomain(Question question)
        {
            var model =  new AskingQuestionModel
            {
                Id = question.id,
                Question = question.TheQuestion,
                Category = question.Category.ToString(),
                Answers = new List<string>
                {
                    question.CorrectAnswer,
                    question.FirstWrongAnswer,
                    question.SecondWrongAnswer,
                    question.ThirdWrongAnswer,
                }
            };

            model.Answers = model.Answers.OrderBy(a => Guid.NewGuid()).ToList();
            return model;
        }
    }
}