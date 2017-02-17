using System;
using System.Collections.Generic;
using System.Linq;
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

        public Profile GetProfile(string userId)
        {
            var repo = new QuestionRepository();
            var submittedRepo = new SubmittedAnswerRepository();
            var submittedAnswers = submittedRepo.GetAll(userId);

            var profile = new Profile();
            var questions = new List<Question>();

            var results = new List<Result>();

            foreach (var submittedAnswer in submittedAnswers)
            {
                questions.Add(repo.Get(submittedAnswer.QuestionId));
            }

            var categories = questions.Select(i => i.Category).Distinct();

            foreach (var category in categories)
            {
                var allQuestions = questions.Where(i => i.Category == category).ToList();
                var count = allQuestions.Count;

                var correct = 0;
                var wrong = 0;
                foreach (var question in allQuestions)
                {
                    var all = submittedAnswers.Where(i => i.QuestionId == question.id).ToList();
                    correct += all.Count(i => i.Correct);
                    wrong += all.Count(i => !i.Correct);
                }

                results.Add(new Result
                {
                    Category = category.ToString(),
                    Correct = correct,
                    Total = count,
                });

            }

            var sortedList = results.OrderByDescending(i => i.Percentage).ToList();

            var strengths = sortedList.Count <= 3 ? sortedList : sortedList.Take(3).ToList();
            sortedList.Reverse();
            var weaknesses = sortedList.Count >= 6 ? sortedList.Take(3).ToList() : sortedList.Take(sortedList.Count - 3).ToList();

            return new Profile
            {
                Strengths = strengths,
                Weaknesses = weaknesses

            };


        }
    }

   


}