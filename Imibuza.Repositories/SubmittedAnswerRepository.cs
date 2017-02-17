using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imibuza.Domain;

namespace Imibuza.Repositories
{
    public class SubmittedAnswerRepository
    {
        private DefaultConnection _defaultConnection;


        public SubmittedAnswerRepository()
        {
            _defaultConnection = new DefaultConnection();
        }

        public void Create(SubmittedAnswer submittedAnswer)
        {
            _defaultConnection.UserAnswers.Add(submittedAnswer);
            _defaultConnection.SaveChanges();

        }

        public List<SubmittedAnswer> GetAll(string userId)
        {
            var results = _defaultConnection.UserAnswers.Where(i => i.UserId == userId).ToList();
            return results.OrderByDescending(i => i.CreatedOn).ToList();

        }
    }
}
