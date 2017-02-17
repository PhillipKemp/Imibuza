using System;
using System.Collections.Generic;
using Imibuza.Domain;
using Imibuza.Repositories;

namespace Imibuza.Services
{
    public class QuestionService
    {
        public bool Create(Question question)
        {
            var repo = new QuestionRepository();
            return repo.Create(question);
        }

        public Question GetRandom()
        {
            var repo = new QuestionRepository();
            return repo.GetRandom();
        }

        public bool SubmitAnswer(SubmittedAnswer submittedAnswer, string answer)
        {
            var repo = new QuestionRepository();
            var submittedRepo = new SubmittedAnswerRepository();
            var question = repo.Get(submittedAnswer.QuestionId);

            submittedAnswer.Correct = question.CorrectAnswer == answer;

            submittedRepo.Create(submittedAnswer);

            return submittedAnswer.Correct;

            
        }

        public Timeline GetTimeline(string userId)
        {
            var repo = new QuestionRepository();
            var submittedRepo = new SubmittedAnswerRepository();
            var submittedAnswers = submittedRepo.GetAll(userId);

            var timeline = new Timeline();
            foreach (var submittedAnswer in submittedAnswers)
            {
                var question = repo.Get(submittedAnswer.QuestionId);
                timeline.Entries.Add(new TimelineEntry()
                {
                    Question = question.TheQuestion,
                    Correct = submittedAnswer.Correct,
                    CompletedOn = submittedAnswer.CreatedOn
                });
            }

            return timeline;

        }
    }
}