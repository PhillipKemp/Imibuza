using System;
using System.Linq;
using Imibuza.Domain;
using Imibuza.Domain.Enums;

namespace Imibuza.Repositories
{
    public class QuestionRepository
    {
        private DefaultConnection _defaultConnection;

        public QuestionRepository()
        {
            _defaultConnection = new DefaultConnection();
        }

        public bool Create(Question question)
        {
            _defaultConnection.Questions.Add(question);
            _defaultConnection.SaveChanges();

            return true;
        }

        public Question GetRandom()
        {
            var questions = _defaultConnection.Questions.ToList();
            if (questions.Count == 0) return null;

            var rnd = new Random().Next(questions.Count);
            var question = questions[rnd];

            return question;
            }

        public Question Get(int id)
        {
            var question = _defaultConnection.Questions.First(i => i.id == id);
            return question;
        }
    }
}